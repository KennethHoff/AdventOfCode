using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal interface ICrateStackSorter
{
	ICrateStacker Sort(ICrateStacker stacks, IEnumerable<CraneMove> craneMoves);
}

internal sealed class DrawingCrateStackSorter : ICrateStackSorter
{
	public ICrateStacker Sort(ICrateStacker stacks, IEnumerable<CraneMove> craneMoves)
	{
		foreach (var move in craneMoves)
		{
			stacks.Transfer(move);
		}

		return stacks;
	}
}