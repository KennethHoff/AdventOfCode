using AdventOfCode.Day3;

Console.WriteLine("Sum of the priorities of items that appear in both compartments: " + new RuckSackOrganizer("data.nlsv")
	.Organize()
	.Select(sack => sack.Compartment1.Items.Where(sack.Compartment2.Items.Contains).Distinct())
	.SelectMany(items => items)
	.Sum(x => x.Priority.Value));
