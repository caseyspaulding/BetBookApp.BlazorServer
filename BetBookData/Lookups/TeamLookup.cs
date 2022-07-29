﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetBookData.Lookups;



public class TeamLookup
{
    public string Team { get; set; }
    public int TeamID { get; set; }
    public UpcomingGame UpcomingGame { get; set; }
    public Teamgametrend[] TeamGameTrends { get; set; }
}

public class UpcomingGame
{
    public string GameKey { get; set; }
    public int SeasonType { get; set; }
    public int Season { get; set; }
    public int Week { get; set; }
    public DateTime Date { get; set; }
    public string AwayTeam { get; set; }
    public string HomeTeam { get; set; }
    public object AwayScore { get; set; }
    public object HomeScore { get; set; }
    public string Channel { get; set; }
    public float PointSpread { get; set; }
    public float OverUnder { get; set; }
    public object Quarter { get; set; }
    public object TimeRemaining { get; set; }
    public object Possession { get; set; }
    public object Down { get; set; }
    public string Distance { get; set; }
    public object YardLine { get; set; }
    public object YardLineTerritory { get; set; }
    public object RedZone { get; set; }
    public object AwayScoreQuarter1 { get; set; }
    public object AwayScoreQuarter2 { get; set; }
    public object AwayScoreQuarter3 { get; set; }
    public object AwayScoreQuarter4 { get; set; }
    public object AwayScoreOvertime { get; set; }
    public object HomeScoreQuarter1 { get; set; }
    public object HomeScoreQuarter2 { get; set; }
    public object HomeScoreQuarter3 { get; set; }
    public object HomeScoreQuarter4 { get; set; }
    public object HomeScoreOvertime { get; set; }
    public bool HasStarted { get; set; }
    public bool IsInProgress { get; set; }
    public bool IsOver { get; set; }
    public bool Has1stQuarterStarted { get; set; }
    public bool Has2ndQuarterStarted { get; set; }
    public bool Has3rdQuarterStarted { get; set; }
    public bool Has4thQuarterStarted { get; set; }
    public bool IsOvertime { get; set; }
    public object DownAndDistance { get; set; }
    public string QuarterDescription { get; set; }
    public int StadiumID { get; set; }
    public DateTime LastUpdated { get; set; }
    public object GeoLat { get; set; }
    public object GeoLong { get; set; }
    public object ForecastTempLow { get; set; }
    public object ForecastTempHigh { get; set; }
    public object ForecastDescription { get; set; }
    public object ForecastWindChill { get; set; }
    public object ForecastWindSpeed { get; set; }
    public int AwayTeamMoneyLine { get; set; }
    public int HomeTeamMoneyLine { get; set; }
    public bool Canceled { get; set; }
    public bool Closed { get; set; }
    public string LastPlay { get; set; }
    public DateTime Day { get; set; }
    public DateTime DateTime { get; set; }
    public int AwayTeamID { get; set; }
    public int HomeTeamID { get; set; }
    public int GlobalGameID { get; set; }
    public int GlobalAwayTeamID { get; set; }
    public int GlobalHomeTeamID { get; set; }
    public int PointSpreadAwayTeamMoneyLine { get; set; }
    public int PointSpreadHomeTeamMoneyLine { get; set; }
    public int ScoreID { get; set; }
    public string Status { get; set; }
    public object GameEndDateTime { get; set; }
    public object HomeRotationNumber { get; set; }
    public object AwayRotationNumber { get; set; }
    public object NeutralVenue { get; set; }
    public object RefereeID { get; set; }
    public int OverPayout { get; set; }
    public int UnderPayout { get; set; }
    public object HomeTimeouts { get; set; }
    public object AwayTimeouts { get; set; }
    public DateTime DateTimeUTC { get; set; }
    public int Attendance { get; set; }
    public StadiumDetailsLookup StadiumDetails { get; set; }
}



public class Teamgametrend
{
    public string Scope { get; set; }
    public int TeamID { get; set; }
    public string Team { get; set; }
    public object OpponentID { get; set; }
    public object Opponent { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Ties { get; set; }
    public int WinsAgainstTheSpread { get; set; }
    public int LossesAgainstTheSpread { get; set; }
    public int PushesAgainstTheSpread { get; set; }
    public int Overs { get; set; }
    public int Unders { get; set; }
    public int OverUnderPushes { get; set; }
    public float AverageScore { get; set; }
    public float AverageOpponentScore { get; set; }
}





