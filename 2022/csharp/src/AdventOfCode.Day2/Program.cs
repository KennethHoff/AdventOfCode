using AdventOfCode.Day2;

Console.WriteLine("Total score if everything goes according to plan: " + new FileParser("data.ssv")
	.GetScores()
	.Select(x => x.Points)
	.OrderDescending()
	.Sum());