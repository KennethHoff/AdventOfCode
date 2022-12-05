using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal interface ICraneOperator
{
	ICrateStacker SortCrateStacks();
}

internal sealed class InefficientCraneOperator : ICraneOperator
{
	private ICrateStacker _inefficientCreateStacker;
	private readonly ICrateStackSorter _crateStackSorter;
	private readonly IReadOnlyCollection<CraneMove> _craneMoves;

	public InefficientCraneOperator(string filePath)
	{
		ICrateStackBlueprintDecoder decoder = new InefficientDrawingCrateStackBlueprintDecoder(filePath);
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

internal sealed class EfficientCraneOperator : ICraneOperator
{
	private ICrateStacker _efficientCreateStacker;
	private readonly ICrateStackSorter _crateStackSorter;
	private readonly IReadOnlyCollection<CraneMove> _craneMoves;

	public EfficientCraneOperator(string filePath)
	{
		ICrateStackBlueprintDecoder decoder = new EfficientDrawingCrateStackBlueprintDecoder(filePath);
		_efficientCreateStacker = decoder.CreateStacks();
		_craneMoves = decoder.CreateMoves();
		_crateStackSorter = new DrawingCrateStackSorter();
	}

	public ICrateStacker SortCrateStacks()
	{
		_efficientCreateStacker = _crateStackSorter.Sort(_efficientCreateStacker, _craneMoves);

		return _efficientCreateStacker;
	}
}