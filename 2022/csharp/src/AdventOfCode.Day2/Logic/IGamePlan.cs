using AdventOfCode.Day2.Models;

namespace AdventOfCode.Day2.Logic;

internal interface IGamePlan
{
	IEnumerable<Score> Execute();
}
