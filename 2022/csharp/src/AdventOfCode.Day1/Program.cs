using AdventOfCode.Day1;

Console.WriteLine("Food for the #1 elf: " + new FileParser("data.nlsv")
	.ParseElves()
	.Select(x => x.TotalCalories)
	.OrderDescending()
	.FirstOrDefault());

Console.WriteLine("Food for the top 3 elves: " + new FileParser("data.nlsv")
	.ParseElves()
	.Select(x => x.TotalCalories)
	.OrderDescending()
	.Take(3)
	.Sum(x => x));
