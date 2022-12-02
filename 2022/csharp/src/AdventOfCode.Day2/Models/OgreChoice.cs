namespace AdventOfCode.Day2.Models;

internal readonly record struct OgreChoice(string Ogre)
{
	public static readonly OgreChoice Rock = new("A");
	public static readonly OgreChoice Paper = new("B");
	public static readonly OgreChoice Scissors = new("C");
}