namespace AdventOfCode.Day01.Models;

internal sealed record class Elf(IReadOnlyCollection<Calorie> Calories)
{
	public int TotalCalories => Calories.Sum(c => c.Value);
}
