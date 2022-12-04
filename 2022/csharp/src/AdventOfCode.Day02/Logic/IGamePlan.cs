using AdventOfCode.Day02.Models;

namespace AdventOfCode.Day02.Logic;

internal interface IGamePlan
{
	IEnumerable<Score> Execute();
}
