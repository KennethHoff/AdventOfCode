using AdventOfCode.Day2.Models;

namespace AdventOfCode.Day2;

internal sealed class FileParser
{
	private const string ValueDelimiter = " ";
	private static readonly string RecordDelimiter = Environment.NewLine;
	
	private readonly string _filePath;

	internal FileParser(string filePath)
	{
		_filePath = filePath;
	}

	internal IReadOnlyCollection<Score> GetScores()
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(fullStr =>
			{
				var choices = fullStr.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries);
				return new Round(new OgreChoice(choices[0]), new PlayerChoice(choices[1]));
			})
			.Select(x => x.Score)
			.ToArray();
}