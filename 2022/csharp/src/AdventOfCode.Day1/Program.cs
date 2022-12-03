using AdventOfCode.Day1.Logic;

Console.WriteLine("Food for the #1 elf: " + new ElfCalorieCalculator("data.nlsv")
	.CalculateCaloriesEachElfIsCarrying()
	.Select(x => x.TotalCalories)
	.OrderDescending()
	.FirstOrDefault());

Console.WriteLine("Food for the top 3 elves: " + new ElfCalorieCalculator("data.nlsv")
	.CalculateCaloriesEachElfIsCarrying()
	.Select(x => x.TotalCalories)
	.OrderDescending()
	.Take(3)
	.Sum(x => x));
