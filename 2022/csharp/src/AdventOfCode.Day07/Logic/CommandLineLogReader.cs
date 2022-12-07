using AdventOfCode.Day07.Models;

namespace AdventOfCode.Day07.Logic;

internal sealed class CommandLineLogReader
{
	private readonly string _filePath;

	public CommandLineLogReader(string filePath)
	{
		_filePath = filePath;
	}

	public FileSystem RecreateFileSystem()
	{
		// var fileSystem = new FileSystem();
		throw new NotImplementedException();
	}
}