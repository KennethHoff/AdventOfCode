namespace AdventOfCode.Day3.Models;

internal sealed record class RuckSack(RuckSackCompartment Compartment1, RuckSackCompartment Compartment2);

internal sealed record class RuckSackCompartment(IReadOnlyCollection<RuckSackItem> Items);