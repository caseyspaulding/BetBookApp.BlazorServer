﻿

using BetBookData.Models;
using MediatR;

namespace BetBookData.Queries;

public record GetBetsQuery() : IRequest<IEnumerable<BetModel>>;
