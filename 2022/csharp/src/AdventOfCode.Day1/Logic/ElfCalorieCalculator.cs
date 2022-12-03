using AdventOfCode.Day1.Models;

namespace AdventOfCode.Day1.Logic;

internal sealed class ElfCalorieCalculator
{
	private static readonly string ValueDelimiter = Environment.NewLine;
	private static readonly string RecordDelimiter = Environment.NewLine + Environment.NewLine;

	private readonly string _filePath;

	public ElfCalorieCalculator(string filePath)
	{
		_filePath = filePath;
	}

	public IReadOnlyCollection<Elf> CalculateCaloriesEachElfIsCarrying()
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(fullStr => new Elf(fullStr
				.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries)
				.Select(calStr => new Calorie(int.Parse(calStr)))
				.ToArray()))
			.ToArray();
}
