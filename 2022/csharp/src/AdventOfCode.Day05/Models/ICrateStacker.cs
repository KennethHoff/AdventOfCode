using AdventOfCode.Day05.Logic;

namespace AdventOfCode.Day05.Models;

internal interface ICrateStacker : IDictionary<CrateStackId, CrateStack>
{
	void Transfer(CraneMove move);
}

internal sealed class InefficientCreateStacker : Dictionary<CrateStackId, CrateStack>, ICrateStacker
{
	public InefficientCreateStacker(IEnumerable<CrateStack> stacks)
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

internal sealed class EfficientCreateStacker : Dictionary<CrateStackId, CrateStack>, ICrateStacker
{
	public EfficientCreateStacker(IEnumerable<CrateStack> stacks)
	{
		foreach (var stack in stacks)
		{
			Add(stack.Id, stack);
		}
	}

	public void Transfer(CraneMove move)
	{
		var crates = new List<Crate>();
		for (var i = 0; i < move.NumberOfCrates; i++)
		{
			crates.Add(this[move.FromStackId].Pop());
		}
		crates.Reverse();
		foreach (var crate in crates)
		{
			this[move.ToStackId].Push(crate);
		}
	}
}