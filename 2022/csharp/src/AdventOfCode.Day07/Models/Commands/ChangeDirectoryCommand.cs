using AdventOfCode.Day07.Extensions;
using AdventOfCode.Day07.Models.FileSystem;

namespace AdventOfCode.Day07.Models.Commands;

internal sealed record class ChangeDirectoryCommand(string DirectoryName) : ICommand
{
	private const string GoUpOneDirectory = "..";
	public FileSystemDirectory ChangeDirectory(IDictionary<string, FileSystemDirectory> fileSystemDirectories, FileSystemDirectory activeDirectory)
		=> DirectoryName switch
		{
			GoUpOneDirectory when activeDirectory.Parent is null => FileSystemDirectory.Root,
			GoUpOneDirectory => activeDirectory.Parent,
			_ => fileSystemDirectories.GetOrAdd(DirectoryName, name => new FileSystemDirectory(name, new HashSet<IFileSystemNode>(), activeDirectory))
		};
}