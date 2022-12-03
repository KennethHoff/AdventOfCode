namespace AdventOfCode.Day3.Models;

internal sealed record class RuckSack(RuckSackCompartment Compartment1, RuckSackCompartment Compartment2)
{
	public IReadOnlyCollection<RuckSackItem> AllItems => Compartment1.Items.Concat(Compartment2.Items).ToArray();
}