namespace AdventOfCode.Day2.Models;

internal sealed record class Round(OgreChoice Ogre, PlayerChoice Player)
{
	public Score Score => Player.CalculateScore(Ogre);
}