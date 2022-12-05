namespace AdventOfCode.Day05.Models;

internal sealed class CrateStack : Stack<Crate>
{
	public readonly CrateStackId Id;

	public CrateStack(IEnumerable<Crate> crates, CrateStackId id)
	{
		Id = id;
		foreach (var crate in crates)
		{
			Push(crate);
		}
	}
}

internal readonly record struct CrateStackId(int Value);
