using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct PlayerChoice(string Player)
{
	public static readonly PlayerChoice Rock = new("X");
	public static readonly PlayerChoice Paper = new("Y");
	public static readonly PlayerChoice Scissors = new("Z");

	public Choice AsChoice => this switch
	{
		_ when this == Rock     => Choice.Rock,
		_ when this == Paper    => Choice.Paper,
		_ when this == Scissors => Choice.Scissors,
		_                       => throw new UnreachableException(),
	};
}
