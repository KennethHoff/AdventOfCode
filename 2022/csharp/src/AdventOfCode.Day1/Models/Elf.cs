namespace AdventOfCode.Day1.Models;

internal sealed record class Elf(IReadOnlyCollection<Calorie> Calories)
{
	internal int TotalCalories => Calories.Sum(c => c.Value);
}
