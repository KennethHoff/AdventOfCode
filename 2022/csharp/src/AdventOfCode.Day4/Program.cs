using AdventOfCode.Day4.Logic;

Console.WriteLine("Day 4");

Console.WriteLine("Number of elves whose jobs are completely useless: " + new OverlappingAssignmentAnalyzer("data.csv")
	.GetAssignments()
	.Count(x => x.IsFullyOverlapping));

Console.WriteLine("Number of elves whose jobs are partially useless: " + new OverlappingAssignmentAnalyzer("data.csv")
	.GetAssignments()
	.Count(x => x.IsPartiallyOverlapping));
