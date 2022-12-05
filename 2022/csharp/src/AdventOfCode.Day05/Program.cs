using AdventOfCode.Day05.Logic;

Console.WriteLine("Day 5");

Console.WriteLine("Inefficient stacking: " + new InefficientCraneOperator("data.skoff")
	.SortCrateStacks()
	.Select(x => x.Value.FirstOrDefault().Value.ToString())
	.Aggregate((x, y) => x + y));

Console.WriteLine("Efficient stacking: " + new EfficientCraneOperator("data.skoff")
	.SortCrateStacks()
	.Select(x => x.Value.FirstOrDefault().Value.ToString())
	.Aggregate((x, y) => x + y));
