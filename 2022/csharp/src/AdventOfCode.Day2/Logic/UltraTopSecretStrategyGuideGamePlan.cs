using AdventOfCode.Day2.Models;

namespace AdventOfCode.Day2.Logic;

internal sealed class UltraTopSecretStrategyGuideGamePlan : IGamePlan
{
	private const string ValueDelimiter = " ";
	private static readonly string RecordDelimiter = Environment.NewLine;

	private readonly string _filePath;

	public UltraTopSecretStrategyGuideGamePlan(string filePath)
	{
		_filePath = filePath;
	}

	#region Interface Implementations

	public IEnumerable<Score> Execute()
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(fullStr =>
			{
				var choices = fullStr.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries);
				var ogreChoice = new OgreChoice(choices[0]);
				PlayerChoice playerChoice = new PlayerChoice.AntiCheat(choices[1], ogreChoice);
				return new Score(playerChoice, ogreChoice);
			});

	#endregion
}
