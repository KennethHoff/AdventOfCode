using AdventOfCode.Day07.Models.Commands;
using AdventOfCode.Day07.Models.FileSystem;

namespace AdventOfCode.Day07.Logic;

internal sealed class CommandLineLogReader
{
	private readonly string _filePath;
	private readonly ICommandExecutor _commandExecutor;

	public CommandLineLogReader(string filePath, ICommandExecutor commandExecutor)
	{
		_filePath = filePath;
		_commandExecutor = commandExecutor;
	}

	public FileSystem RecreateFileSystem()
	{
		var lines = File.ReadAllLines(_filePath);
		var commandDecipherer = new StringDecipheringCommandDecipherer(lines);
		
		var commands = commandDecipherer.GetAll()
			.Where(x => x is not DoNothingCommand)
			.ToList();
		
		var result = _commandExecutor.ExecuteAll(commands);
		
		return new FileSystem(result);
	}
}