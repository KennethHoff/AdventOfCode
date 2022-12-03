using AdventOfCode.Day3.Logic;

Console.WriteLine("Sum of the priorities of items that appear in both compartments: " + new RuckSackOrganizer("data.nlsv")
	.Organize()
	.Select(sack => sack.Compartment1.Items.Where(sack.Compartment2.Items.Contains).Distinct())
	.SelectMany(items => items)
	.Sum(x => x.Priority.Value));

Console.WriteLine("Sum of the priorities of the badges: " + new RuckSackOrganizer("data.nlsv")
	.Organize()
	.Chunk(3)
	.Select(group => group
		.SelectMany(sack => sack.AllItems)
		.Distinct()
		.Where(item => group
			.All(elf => elf.AllItems
				.Contains(item))))
	.SelectMany(items => items)
	.Sum(x => x.Priority.Value));
