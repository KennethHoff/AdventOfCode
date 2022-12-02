using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct Score(Choice Player, Choice Ogre)
{
	private const int AdditionalWinPoints = 6;
	private const int AdditionalDrawPoints = 3;
	private const int AdditionalLossPoints = 0;

	private const int ScissorsChoicePoints = 3;
	private const int PaperChoicePoints = 2;
	private const int RockChoicePoints = 1;

	public int Points => (Player, Ogre) switch
	{
		(Player: Choice.Paper, Ogre: Choice.Rock)        => PaperChoicePoints + AdditionalWinPoints,
		(Player: Choice.Paper, Ogre: Choice.Scissors)    => PaperChoicePoints + AdditionalLossPoints,
		(Player: Choice.Paper, Ogre: Choice.Paper)       => PaperChoicePoints + AdditionalDrawPoints,
		(Player: Choice.Rock, Ogre: Choice.Scissors)     => RockChoicePoints + AdditionalWinPoints,
		(Player: Choice.Rock, Ogre: Choice.Paper)        => RockChoicePoints + AdditionalLossPoints,
		(Player: Choice.Rock, Ogre: Choice.Rock)         => RockChoicePoints + AdditionalDrawPoints,
		(Player: Choice.Scissors, Ogre: Choice.Paper)    => ScissorsChoicePoints + AdditionalWinPoints,
		(Player: Choice.Scissors, Ogre: Choice.Rock)     => ScissorsChoicePoints + AdditionalLossPoints,
		(Player: Choice.Scissors, Ogre: Choice.Scissors) => ScissorsChoicePoints + AdditionalDrawPoints,
		_                                                => throw new UnreachableException(),
	};
}