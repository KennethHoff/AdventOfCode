using AdventOfCode.Day05.Logic;

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

internal sealed class CrateStacks : Dictionary<CrateStackId, CrateStack>
{
	public CrateStacks(IEnumerable<CrateStack> stacks)
	{
		foreach (var stack in stacks)
		{
			Add(stack.Id, stack);
		}
	}
	
	public void Transfer(CraneMove move)
	{
		for (var i = 0; i < move.NumberOfCrates; i++)
		{
			var crate = this[move.FromStackId].Pop();
			this[move.ToStackId].Push(crate);
		}
	}
}

internal readonly record struct CrateStackId(int Value);
