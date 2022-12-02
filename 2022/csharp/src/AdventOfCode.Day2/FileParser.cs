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

	internal IReadOnlyCollection<Score> GetScores(bool beSneaky)
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(fullStr =>
			{
				var choices = fullStr.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries);
				var ogreChoice = new OgreChoice(choices[0]);
				var playerChoice = beSneaky switch
				{
					false => new PlayerChoice(choices[1]),
					true  => new PlayerChoice.AntiCheat(choices[1], ogreChoice),
				};
				return new Score(playerChoice, ogreChoice);
			})
			.ToArray();
}
