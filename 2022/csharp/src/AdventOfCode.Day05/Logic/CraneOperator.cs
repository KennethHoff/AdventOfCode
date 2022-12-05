using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal sealed class CraneOperator
{
	private CrateStacks _crateStacks;
	private readonly ICrateStackSorter _crateStackSorter;
	private readonly IReadOnlyCollection<CraneMove> _craneMoves;

	public CraneOperator(string filePath)
	{
		ICrateStackBlueprintDecoder decoder = new DrawingCrateStackBlueprintDecoder(filePath);
		_crateStacks = decoder.CreateStacks();
		_craneMoves = decoder.CreateMoves();
		_crateStackSorter = new DrawingCrateStackSorter();
	}

	public CrateStacks SortCrateStacks()
	{
		_crateStacks = _crateStackSorter.Sort(_crateStacks, _craneMoves);

		return _crateStacks;
	}
}