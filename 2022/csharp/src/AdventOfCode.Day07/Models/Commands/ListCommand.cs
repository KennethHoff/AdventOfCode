using System.Diagnostics;
using AdventOfCode.Day07.Extensions;
using AdventOfCode.Day07.Models.FileSystem;

namespace AdventOfCode.Day07.Models.Commands;

internal sealed record class ListCommand(IReadOnlyCollection<string> SupplementaryLines) : ICommand
{
	public IEnumerable<IFileSystemNode> ListItems(IDictionary<string, FileSystemDirectory> allDirectories, FileSystemDirectory activeDirectory)
		=> SupplementaryLines
			.Select(line =>
			{
				IFileSystemNode fileSystemNode = line.Split(' ') switch
				{
					["dir", var directoryName] => allDirectories.GetOrAdd(directoryName, name 
						=> new FileSystemDirectory(name, new HashSet<IFileSystemNode>(), activeDirectory)),
					[var size, var fileName]   => new FileSystemFile(fileName, int.Parse(size)),
					_                          => throw new UnreachableException(),
				};
				return fileSystemNode;
			});
}