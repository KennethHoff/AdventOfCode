using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct Score(PlayerChoice Player, OgreChoice Ogre)
{
	private const int AdditionalWinPoints = 6;
	private const int AdditionalDrawPoints = 3;
	private const int AdditionalLossPoints = 0;

	private const int ScissorsChoicePoints = 3;
	private const int PaperChoicePoints = 2;
	private const int RockChoicePoints = 1;

	private Choice OgreChoice => Ogre.AsChoice;
	private Choice PlayerChoice => Player.AsChoice;

	public int Points => (PlayerChoice, OgreChoice) switch
	{
		(PlayerChoice: Choice.Paper, OgreChoice: Choice.Rock)        => PaperChoicePoints + AdditionalWinPoints,
		(PlayerChoice: Choice.Paper, OgreChoice: Choice.Scissors)    => PaperChoicePoints + AdditionalLossPoints,
		(PlayerChoice: Choice.Paper, OgreChoice: Choice.Paper)       => PaperChoicePoints + AdditionalDrawPoints,
		(PlayerChoice: Choice.Rock, OgreChoice: Choice.Scissors)     => RockChoicePoints + AdditionalWinPoints,
		(PlayerChoice: Choice.Rock, OgreChoice: Choice.Paper)        => RockChoicePoints + AdditionalLossPoints,
		(PlayerChoice: Choice.Rock, OgreChoice: Choice.Rock)         => RockChoicePoints + AdditionalDrawPoints,
		(PlayerChoice: Choice.Scissors, OgreChoice: Choice.Paper)    => ScissorsChoicePoints + AdditionalWinPoints,
		(PlayerChoice: Choice.Scissors, OgreChoice: Choice.Rock)     => ScissorsChoicePoints + AdditionalLossPoints,
		(PlayerChoice: Choice.Scissors, OgreChoice: Choice.Scissors) => ScissorsChoicePoints + AdditionalDrawPoints,
		_                                                            => throw new UnreachableException(),
	};
}