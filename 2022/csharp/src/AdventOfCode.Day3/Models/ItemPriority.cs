namespace AdventOfCode.Day3.Models;

internal readonly record struct ItemPriority(char Letter)
{
	// a -> 1, b -> 2, z -> 26
	// A -> 27, B -> 28, Z -> 52
	public int Value => Letter switch
	{
		>= 'a' and <= 'z' => Letter - 'a' + 1,
		>= 'A' and <= 'Z' => Letter - 'A' + 27,
		_                 => throw new ArgumentOutOfRangeException(nameof(Letter), Letter, "Value must be a letter"),
	};
}
