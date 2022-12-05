using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal interface ICrateStackBlueprintDecoder
{
	IReadOnlyCollection<CraneMove> CreateMoves();
	ICrateStacker CreateStacks();
}

internal sealed class DrawingCrateStackBlueprintDecoder<TCrateStacker> : ICrateStackBlueprintDecoder
	where TCrateStacker : ICrateStacker
{
	// Example of a stack:
	// [A] [B] [S] [D] [H]     [T]
	// [A] [B] [C] [D] [G]     [R] 
	// [A] [B] [G] [D] [F]     [E] 
	// [A] [B] [C] [E] [E]     [X] [D] [Z]
	// [A] [B] [Z] [D] [D]     [V] [E] [D]
	// [Z] [B] [C] [D] [E]     [G] [H] [E]
	// [A] [B] [C] [C] [E] [F] [G] [H] [R]
	//  1   2   3   4   5   6   7   8   9   
	//
	// move x from y to z
	// move a from b to c
	// ...

	private readonly string[] _blueprint;
	private readonly int _numberOfStacks;
	private readonly int _tallestStack;
	private int LineContainingStackId => _tallestStack + 1;

	private int StartOfMoves => _tallestStack + 3;

	public DrawingCrateStackBlueprintDecoder(string filePath)
	{
		_blueprint = File.ReadAllLines(filePath);
		_tallestStack = _blueprint
			.TakeWhile(line => !line.Any(char.IsDigit))
			.Count() - 1;
		_numberOfStacks = _blueprint[LineContainingStackId]
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.Max();
	}

	#region Interface Implementations

	public IReadOnlyCollection<CraneMove> CreateMoves()
		=> _blueprint
			.Skip(StartOfMoves)
			.Select(x => new CraneMove(x))
			.ToArray();

	public ICrateStacker CreateStacks()
		=> TCrateStacker.Create(Enumerable.Range(1, _numberOfStacks)
			.Select(number =>
			{
				var columStartIndex = _blueprint[LineContainingStackId]
					.IndexOf(number.ToString(), StringComparison.Ordinal);

				var crates = _blueprint
					.Take(LineContainingStackId)
					.Select(line => line[columStartIndex])
					.Where(char.IsLetter)
					.Select(x => new Crate(x))
					.Reverse();

				return new CrateStack(crates, new CrateStackId(number));
			}));

	#endregion
}
