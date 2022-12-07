using AdventOfCode.Day07.Logic;
using AdventOfCode.Day07.Models.FileSystem;

Console.WriteLine("Day 7");

var fileSystemDirectories = new CommandLineLogReader("data.cll", new CommandExecutor())
	.RecreateFileSystem()
	.Directories
	.ToArray();



var circularReferences = fileSystemDirectories
	.Select(d => d.NonCircularDirectories)
	.Where(x => x.Any(y => y.Name == "mfmps"));

Console.WriteLine("End of Day 7");

// var nonEmptyDirectories = fileSystemDirectories
// 	.Where(x => x.AllFiles.Any())
// 	.ToArray();
// var sum = nonEmptyDirectories
// 	.Select(x => x.AllFiles.Sum(y => y.Size))
// 	.ToArray();
// var ofMaximumSize = sum
// 	.Where(x => x <= 100_000)
// 	.ToArray();
// var i = ofMaximumSize
// 	.Sum();
// Console.WriteLine("Total size of directories with a size of at most 100'000: " + i);

// Console.WriteLine("Total size of directories with a size of at most 100'000: " + new CommandLineLogReader("data.cll", new CommandExecutor())
// 	.RecreateFileSystem()
// 	.Directories
// 	.Where(x => x.AllFiles.Any())
// 	.Select(x => x.AllFiles.Sum(y => y.Size))
// 	.Where(x => x <= 100_000)
// 	.Sum());