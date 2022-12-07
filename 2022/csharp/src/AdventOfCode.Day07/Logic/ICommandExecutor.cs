using System.Diagnostics;
using AdventOfCode.Day07.Models.Commands;
using AdventOfCode.Day07.Models.FileSystem;

namespace AdventOfCode.Day07.Logic;

internal interface ICommandExecutor
{
	IEnumerable<FileSystemDirectory> ExecuteAll(IEnumerable<ICommand> commands);
}

internal sealed class CommandExecutor : ICommandExecutor
{
	private FileSystemDirectory _currentDirectory = FileSystemDirectory.Root;
	
	private void ReplaceCurrentDirectory(FileSystemDirectory newDirectory)
	{
		if (newDirectory == _currentDirectory)
		{
			return;
		}

		_currentDirectory.Children.Add(newDirectory);
		_currentDirectory = newDirectory;
	}

	private readonly IDictionary<string, FileSystemDirectory> _allDirectories = new Dictionary<string, FileSystemDirectory>()
	{
		{ FileSystemDirectory.Root.Name, FileSystemDirectory.Root },
	};
	
	public IEnumerable<FileSystemDirectory> ExecuteAll(IEnumerable<ICommand> commands)
	{
		foreach (var command in commands)
		{
			switch (command)
			{
				case ChangeDirectoryCommand changeDirectoryCommand:
					var newDirectory = changeDirectoryCommand.ChangeDirectory(_allDirectories, _currentDirectory);
					ReplaceCurrentDirectory(newDirectory);
					break;
				case ListCommand listCommand:
					var childNodes = listCommand.ListItems(_allDirectories, _currentDirectory)
						.ToArray();

					foreach (var node in childNodes)
					{
						_currentDirectory.Children.Add(node);
					}
					break;
				case DoNothingCommand:
					break;
				default:
					throw new UnreachableException();
			}
		}
		
		return _allDirectories.Values;
	}
}
