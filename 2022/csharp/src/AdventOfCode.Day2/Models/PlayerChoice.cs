using System.Diagnostics;

namespace AdventOfCode.Day2.Models;

internal readonly record struct PlayerChoice(string Player)
{
	private static readonly PlayerChoice Rock = new("X");
	private static readonly PlayerChoice Paper = new("Y");
	private static readonly PlayerChoice Scissors = new("Z");

	private Choice AsChoice => this switch
	{
		_ when this == Rock     => Choice.Rock,
		_ when this == Paper    => Choice.Paper,
		_ when this == Scissors => Choice.Scissors,
		_                       => throw new UnreachableException(),
	};

	// Implicit conversion to Choice
	public static implicit operator Choice(PlayerChoice playerChoice)
		=> playerChoice.AsChoice;

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
				_ when Ogre == Choice.Rock     => Rock,
				_ when Ogre == Choice.Paper    => Paper,
				_ when Ogre == Choice.Scissors => Scissors,
				_                              => throw new UnreachableException(),
			};

		private PlayerChoice CalculateLosingMove()
			=> this switch
			{
				_ when Ogre == Choice.Rock     => Scissors,
				_ when Ogre == Choice.Paper    => Rock,
				_ when Ogre == Choice.Scissors => Paper,
				_                              => throw new UnreachableException(),
			};

		private PlayerChoice CalculateWinningMove()
			=> this switch
			{
				_ when Ogre == Choice.Rock     => Paper,
				_ when Ogre == Choice.Paper    => Scissors,
				_ when Ogre == Choice.Scissors => Rock,
				_                              => throw new UnreachableException(),
			};

		// In order to further hide the anti-cheat, we make an implicit conversion from AntiCheat to PlayerChoice ;=) 
		public static implicit operator PlayerChoice(AntiCheat choice)
			=> choice.AsPlayerChoice;
	}
}
