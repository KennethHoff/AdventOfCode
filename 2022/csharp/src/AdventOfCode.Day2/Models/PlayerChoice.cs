using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct PlayerChoice(string Player)
{
	private static readonly PlayerChoice Rock = new("X");
	private static readonly PlayerChoice Paper = new("Y");
	private static readonly PlayerChoice Scissors = new("Z");

	// This doesn't really make sense to be placed here
	public Score CalculateScore(OgreChoice ogreChoice)
		=> this switch
		{
			_ when this == Rock && ogreChoice == OgreChoice.Rock         => new Score(Winner.Draw, Choice.Rock),
			_ when this == Rock && ogreChoice == OgreChoice.Paper        => new Score(Winner.Ogre, Choice.Paper),
			_ when this == Rock && ogreChoice == OgreChoice.Scissors     => new Score(Winner.Player, Choice.Rock),
			_ when this == Paper && ogreChoice == OgreChoice.Rock        => new Score(Winner.Player, Choice.Paper),
			_ when this == Paper && ogreChoice == OgreChoice.Paper       => new Score(Winner.Draw, Choice.Paper),
			_ when this == Paper && ogreChoice == OgreChoice.Scissors    => new Score(Winner.Ogre, Choice.Scissors),
			_ when this == Scissors && ogreChoice == OgreChoice.Rock     => new Score(Winner.Ogre, Choice.Rock),
			_ when this == Scissors && ogreChoice == OgreChoice.Paper    => new Score(Winner.Player, Choice.Scissors),
			_ when this == Scissors && ogreChoice == OgreChoice.Scissors => new Score(Winner.Draw, Choice.Scissors),
			_                                                            => throw new UnreachableException(),
		};
}
