using System.Diagnostics;
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

	internal IReadOnlyCollection<Score> ExecuteStrategy(bool beSneaky)
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(fullStr => new Score(fullStr.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries) switch
			{
				[var ogre, var player] when beSneaky => (new OgreChoice(ogre), new PlayerChoice.AntiCheat(player, new OgreChoice(ogre))),
				[var ogre, var player]               => (new OgreChoice(ogre), new PlayerChoice(player)),
				_                                    => throw new UnreachableException(),
			}))
			.ToArray();
}
