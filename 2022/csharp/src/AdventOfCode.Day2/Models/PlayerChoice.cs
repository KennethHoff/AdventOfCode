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

	// Gotta hide the fact that we have an anti-cheat by moving it inside the PlayerChoice class ;)
	internal readonly record struct AntiCheat(string Player, OgreChoice Ogre)
	{
		private static readonly AntiCheat Lose = new("X", default);
		private static readonly AntiCheat Draw = new("Y", default);
		private static readonly AntiCheat Win = new("Z", default);

		private PlayerChoice AsPlayerChoice => this switch
		{
			_ when Player == Lose.Player => CalculateLosingMove(),
			_ when Player == Draw.Player => CalculateDrawingMove(),
			_ when Player == Win.Player  => CalculateWinningMove(),
			_                            => throw new UnreachableException(),
		};

		private PlayerChoice CalculateDrawingMove()
			=> this switch
			{
				_ when Ogre == OgreChoice.Rock     => Rock,
				_ when Ogre == OgreChoice.Paper    => Paper,
				_ when Ogre == OgreChoice.Scissors => Scissors,
				_                                  => throw new UnreachableException(),
			};

		private PlayerChoice CalculateLosingMove()
			=> this switch
			{
				_ when Ogre == OgreChoice.Rock     => Scissors,
				_ when Ogre == OgreChoice.Paper    => Rock,
				_ when Ogre == OgreChoice.Scissors => Paper,
				_                                  => throw new UnreachableException(),
			};

		private PlayerChoice CalculateWinningMove()
			=> this switch
			{
				_ when Ogre == OgreChoice.Rock     => Paper,
				_ when Ogre == OgreChoice.Paper    => Scissors,
				_ when Ogre == OgreChoice.Scissors => Rock,
				_                                  => throw new UnreachableException(),
			};

		// In order to further hide the anti-cheat, we make an implicit conversion from AntiCheat to PlayerChoice ;=) 
		public static implicit operator PlayerChoice(AntiCheat choice)
			=> choice.AsPlayerChoice;
	}
}
