using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal interface ICrateStackSorter
{
	CrateStacks Sort(CrateStacks stacks, IEnumerable<CraneMove> craneMoves);
}

internal sealed class DrawingCrateStackSorter : ICrateStackSorter
{
	public CrateStacks Sort(CrateStacks stacks, IEnumerable<CraneMove> craneMoves)
	{
		foreach (var move in craneMoves)
		{
			stacks.Transfer(move);
		}

		return stacks;
	}
}