﻿using BetBookData.Interfaces;
using BetBookData.Models;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Extensions.Logging;
using BetBookDbAccess;

namespace BetBookData.Data;

#nullable enable

public class BetData : IBetData
{

    private readonly ISqlConnection _db;
    private readonly IConfiguration _config;
    private readonly ILogger<BetData> _logger;

    public BetData(ISqlConnection db, IConfiguration config, ILogger<BetData> logger)
    {
        _db = db;
        _config = config;
        _logger = logger;
    }

    public async Task<IEnumerable<BetModel>> GetBets() 
    {
        _logger.LogInformation(message: "Http Get / Get Bets");

        return await _db.LoadData<BetModel, dynamic>(
            "dbo.spBets_GetAll", new { });
    }

    public async Task<BetModel?> GetBet(int betId)
    {
        _logger.LogInformation(message: "Http Get / Get Bet");

        var result = await _db.LoadData<BetModel, dynamic>(
            "dbo.spBets_Get", new
            {
                Id = betId
            });

        return result.FirstOrDefault();
    }

    public async Task<int> InsertBet(BetModel bet)
    {
        string betStatus = BetStatus.IN_PROGRESS.ToString();
        string payoutStatus;

        payoutStatus = bet.PayoutStatus == PayoutStatus.PARLEY ? PayoutStatus.PARLEY.ToString() 
                       : PayoutStatus.UNPAID.ToString();

        using IDbConnection connection = new System.Data.SqlClient.SqlConnection(
            _config.GetConnectionString("BetBookDB"));

        var p = new DynamicParameters();

        p.Add("@BetAmount", bet.BetAmount);
        p.Add("@BetPayout", bet.BetPayout);
        p.Add("@BettorId", bet.BettorId);
        p.Add("@GameId", bet.GameId);
        p.Add("@ChosenWinnerId", bet.ChosenWinnerId);
        p.Add("@BetStatus", betStatus);
        p.Add("@PayoutStatus", payoutStatus);
        p.Add("@PointSpread", bet.PointSpread);
        p.Add( "@Id", 0, dbType: DbType.Int32,
            direction: ParameterDirection.Output);

        try
        {
            _logger.LogInformation(message: "Http Post / Insert Bet");
            await connection.ExecuteAsync(
                "dbo.spBets_Insert", p, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "Exception On Insert Bet");
        }

        return bet.Id = p.Get<int>("@Id");
    }

    public async Task UpdateBet(BetModel bet)
    {
        string betStatus = bet.BetStatus.ToString();
        string payoutStatus = bet.PayoutStatus.ToString();

        _logger.LogInformation(message: "Http Put / Update Bet");

        await _db.SaveData("dbo.spBets_Update", new
        {
            bet.Id,
            bet.BetAmount,
            bet.BetPayout,
            bet.BettorId,
            bet.GameId,
            bet.ChosenWinnerId,
            bet.FinalWinnerId,
            betStatus,
            payoutStatus,
            bet.PointSpread
        });
    }

    public async Task DeleteBet(int id)
    {
        _logger.LogInformation(message: "Http Delete / Delete Bet");

        await _db.SaveData(
        "dbo.spBets_Delete", new
        {
            Id = id
        });
    }
}

#nullable restore
