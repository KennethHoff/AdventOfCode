namespace AdventOfCode.Day1.Models;

public sealed record class Elf(IReadOnlyCollection<Calorie> Calories)
{
	public int TotalCalories => Calories.Sum(c => c.Value);
}