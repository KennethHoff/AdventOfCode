using AdventOfCode.Day2;
using AdventOfCode.Day2.Models;

Console.WriteLine("Total score if everything goes according to plan: " + new FileParser("data.ssv")
	.GetScores()
	.Select(x => x.Points)
	.OrderDescending()
	.Sum());