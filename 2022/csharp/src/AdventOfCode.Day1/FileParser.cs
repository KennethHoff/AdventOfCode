using AdventOfCode.Day1.Models;

namespace AdventOfCode.Day1;

public sealed class FileParser
{
	private static readonly string ValueDelimiter = Environment.NewLine;
	private static readonly string RecordDelimiter = Environment.NewLine + Environment.NewLine;

	private readonly string _filePath;
	public FileParser(string filePath)
	{
		_filePath = filePath;
	}

	public IReadOnlyCollection<Elf> ParseElves()
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(fullStr => new Elf(fullStr
				.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries)
				.Select(calStr => new Calorie(int.Parse(calStr)))
				.ToArray()))
			.ToArray();
}