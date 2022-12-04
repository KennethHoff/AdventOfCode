using System.Diagnostics;

namespace AdventOfCode.Day02.Models;

internal readonly record struct OgreChoice(string Ogre)
{
	private static readonly OgreChoice Rock = new("A");
	private static readonly OgreChoice Paper = new("B");
	private static readonly OgreChoice Scissors = new("C");

	private Choice AsChoice => this switch
	{
		_ when this == Rock     => Choice.Rock,
		_ when this == Paper    => Choice.Paper,
		_ when this == Scissors => Choice.Scissors,
		_                       => throw new UnreachableException(),
	};

	// Implicit conversion to Choice
	public static implicit operator Choice(OgreChoice choice)
		=> choice.AsChoice;
}
