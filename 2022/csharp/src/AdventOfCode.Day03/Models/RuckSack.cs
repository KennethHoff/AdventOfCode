namespace AdventOfCode.Day03.Models;

internal sealed record class RuckSack(RuckSackCompartment Compartment1, RuckSackCompartment Compartment2)
{
	public IEnumerable<RuckSackItem> AllItems => Compartment1.Items.Concat(Compartment2.Items);
}
