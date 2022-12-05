using AdventOfCode.Day05.Models;

namespace AdventOfCode.Day05.Logic;

internal readonly struct CraneMove
{
	private readonly IReadOnlyList<string> _parts;
	public CraneMove(string line)
	{
		_parts = line.Split(' ');
	}

	public int NumberOfCrates => int.Parse(_parts[1]);
	public CrateStackId FromStackId => new(int.Parse(_parts[3]));
	public CrateStackId ToStackId => new(int.Parse(_parts[5]));
}
