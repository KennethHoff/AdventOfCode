namespace AdventOfCode.Day07.Models.FileSystem;

internal readonly record struct FileSystemFile(string Name, int Size) : IFileSystemNode;