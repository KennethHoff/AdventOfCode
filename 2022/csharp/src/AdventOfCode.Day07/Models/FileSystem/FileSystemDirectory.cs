namespace AdventOfCode.Day07.Models.FileSystem;

internal sealed record class FileSystemDirectory(string Name, HashSet<IFileSystemNode> Children, FileSystemDirectory? Parent) : IFileSystemNode
{
	public static readonly FileSystemDirectory Root = new("/", new HashSet<IFileSystemNode>(), null);
	
	public IEnumerable<FileSystemFile> Files => Children.OfType<FileSystemFile>();
	public IEnumerable<FileSystemDirectory> Directories => Children.OfType<FileSystemDirectory>();
	
	public IEnumerable<FileSystemDirectory> NonCircularDirectories => Directories.Where(d => d != this);

	public IEnumerable<FileSystemFile> AllFiles
	{
		get
		{
			foreach (var file in Files)
			{
				yield return file;
			}

			foreach (var directory in NonCircularDirectories)
			{
				foreach (var file in directory.AllFiles)
				{
					yield return file;
				}
			}
		}
	}
}