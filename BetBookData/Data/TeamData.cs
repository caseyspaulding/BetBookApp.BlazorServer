﻿using BetBookData.Models;
using BetBookData.Interfaces;
using BetBookData.DbAccess;
using Microsoft.Extensions.Logging;

namespace BetBookData.Data;

#nullable enable

public class TeamData : ITeamData
{
    private readonly ISqlConnection _db;
    private readonly ILogger<TeamData> _logger;

    public TeamData(ISqlConnection db, ILogger<TeamData> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<TeamModel>> GetTeams()
    {
        _logger.LogInformation(message: "Http Get / Get Teams");

        return await _db.LoadData<TeamModel, dynamic>(
            "dbo.spTeams_GetAll", new { });
    }

    public async Task<TeamModel?> GetTeam(int id)
    {
        _logger.LogInformation(message: "Http Get / Get Team");

        var results = await _db.LoadData<TeamModel, dynamic>(
            "dbo.spTeams_Get", new
            {
                Id = id
            });

        return results.FirstOrDefault();
    }

    public async Task<int> InsertTeam(TeamModel team)
    {
        _logger.LogInformation(message: "Http Post / Insert Team");

        await _db.SaveData("dbo.spTeams_Insert", new
        {
            team.TeamName,
            team.City,
            team.Stadium,
            team.Wins,
            team.Losses,
            team.Draws,
            team.Symbol,
            team.Division,
            team.Conference
        });

        return team.Id;
    }

    public async Task UpdateTeam(TeamModel team)
    {
        _logger.LogInformation(message: "Http Put / Update Team");

        await _db.SaveData("dbo.spTeams_Update", new
        {
            team.Id,
            team.TeamName,
            team.City,
            team.Stadium,
            team.Wins,
            team.Losses,
            team.Draws,
            team.Symbol,
            team.Division,
            team.Conference
        });
    }

    public async Task DeleteTeam(int id)
    {
        _logger.LogInformation(message: "Http Delete / Delete Team");

        await _db.SaveData(
        "dbo.spTeams_Delete", new
        {
            Id = id
        });
    }
}

#nullable restore
