namespace AdventOfCode.Day07.Models;

internal interface INode
{
	public string Name { get; }
}

internal readonly record struct Directory(string Name, IEnumerable<INode> Children) : INode;
internal readonly record struct File(string Name, int Size) : INode;

internal sealed record class FileSystem(IEnumerable<Directory> Directories);
