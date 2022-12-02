using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct Score(Winner Winner, Choice Choice)
{
	private const int ScissorWin = 3;
	private const int PaperWin = 2;
	private const int RockWin = 1;
	private const int Draw = 0;

	private const int AdditionalWinPoints = 6;
	private const int AdditionalLosePoints = 0;
	private const int AdditionalDrawPoints = 3;
	
	public int Points => Winner switch
	{
		Winner.Player => Choice switch
		{
			Choice.Scissors => ScissorWin + AdditionalWinPoints,
			Choice.Paper => PaperWin + AdditionalWinPoints,
			Choice.Rock => RockWin + AdditionalWinPoints,
			_ => throw new UnreachableException(),
		},
		Winner.Ogre => Choice switch
		{
			Choice.Scissors => -ScissorWin + AdditionalLosePoints,
			Choice.Paper => -PaperWin + AdditionalLosePoints,
			Choice.Rock => -RockWin + AdditionalLosePoints,
			_ => throw new UnreachableException(),
		},
		Winner.Draw => Draw + AdditionalDrawPoints,
		_           => throw new UnreachableException(),
	};
}