﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetBookDataLogic.Models;
public class BasicGameModel
{
    // Id of the basic game model
    public int Id { get; set; }

    // Id of the game of the basic game model
    public int GameId { get; set; }

    // Name of the home team
    public string HomeTeamName { get; set; }

    // Name of the away team
    public string AwayTeamName { get; set; }

    // Name of the favorited team
    public string FavoriteTeamName { get; set; }

    // Name of the underdog team
    public string UnderdogTeamName { get; set; }

    // Point spread of the game
    public int PointSpread { get; set; }
}
