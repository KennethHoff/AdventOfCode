using System.Globalization;
using AdventOfCode.Day07.Logic;

Console.WriteLine("Day 7");

Console.WriteLine("Total size of directories with a size of at most 100'000: " + new CommandLineLogReader("data.cll")
	.RecreateFileSystem()
	.Where(d => d.Size <= 100000)
	.Sum(d => d.Size).ToString(CultureInfo.InvariantCulture));