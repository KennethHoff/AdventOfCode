using AdventOfCode.Day05.Logic;

Console.WriteLine("Day 5");

Console.WriteLine(new CraneOperator("data.skoff")
	.SortCrateStacks()
	.Select(x => x.Value.FirstOrDefault().Value.ToString())
	.Aggregate((x, y) => x + y));

