using AdventOfCode.Day05.Logic;
using AdventOfCode.Day05.Models;

Console.WriteLine("Day 5");

Console.WriteLine("Inefficient stacking: " + new CraneOperator<InefficientCrateStacker>("data.scuff")
	.SortCrateStacks()
	.Select(x => x.Value.FirstOrDefault().Value.ToString())
	.Aggregate((x, y) => x + y));

Console.WriteLine("Efficient stacking: " + new CraneOperator<EfficientCrateStacker>("data.scuff")
	.SortCrateStacks()
	.Select(x => x.Value.FirstOrDefault().Value.ToString())
	.Aggregate((x, y) => x + y));
