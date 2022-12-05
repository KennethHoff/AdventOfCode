using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal sealed class CraneOperator<TCrateStacker>
	where TCrateStacker : ICrateStacker
{
	private ICrateStacker _inefficientCreateStacker;
	private readonly ICrateStackSorter _crateStackSorter;
	private readonly IReadOnlyCollection<CraneMove> _craneMoves;

	public CraneOperator(string filePath)
	{
		ICrateStackBlueprintDecoder decoder = new DrawingCrateStackBlueprintDecoder<TCrateStacker>(filePath);
		_inefficientCreateStacker = decoder.CreateStacks();
		_craneMoves = decoder.CreateMoves();
		_crateStackSorter = new DrawingCrateStackSorter();
	}

	public ICrateStacker SortCrateStacks()
	{
		_inefficientCreateStacker = _crateStackSorter.Sort(_inefficientCreateStacker, _craneMoves);

		return _inefficientCreateStacker;
	}
}