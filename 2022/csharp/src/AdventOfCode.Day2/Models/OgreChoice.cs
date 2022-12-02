using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct OgreChoice(string Ogre)
{
	public static readonly OgreChoice Rock = new("A");
	public static readonly OgreChoice Paper = new("B");
	public static readonly OgreChoice Scissors = new("C");

	public Choice AsChoice => this switch
	{
		_ when this == Rock     => Choice.Rock,
		_ when this == Paper    => Choice.Paper,
		_ when this == Scissors => Choice.Scissors,
		_                       => throw new UnreachableException(),
	};
}