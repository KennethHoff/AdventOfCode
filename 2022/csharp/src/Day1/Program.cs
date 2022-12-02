var valueDelimiter = Environment.NewLine;
var recordDelimiter = Environment.NewLine + Environment.NewLine;

Console.WriteLine(File.ReadAllText("data.nlsv")
	.Split(recordDelimiter, StringSplitOptions.RemoveEmptyEntries)
	.Select(fullStr => new Elf(fullStr
		.Split(valueDelimiter, StringSplitOptions.RemoveEmptyEntries)
		.Select(calStr => new Calorie(int.Parse(calStr)))
		.ToArray()))
	.Select(x => x.TotalCalories)
	.OrderDescending()
	.FirstOrDefault());

internal readonly record struct Elf(IReadOnlyCollection<Calorie> Calories)
{
	public int TotalCalories => Calories.Sum(c => c.Value);
}

internal readonly record struct Calorie(int Value);
