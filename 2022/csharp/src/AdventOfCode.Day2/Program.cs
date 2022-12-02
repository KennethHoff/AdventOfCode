using AdventOfCode.Shared;

Console.WriteLine(new FileParser("data.nlsv")
	.ParseElves()
	.Select(x => x.TotalCalories)
	.OrderDescending()
	.Take(3)
	.Sum(x => x));