using AdventOfCode.Day02.Logic;

Console.WriteLine("Day 2");

Console.WriteLine("Total score if everything goes according to plan: " + new EncryptedStrategyGuideGamePlan("data.ssv")
	.Execute()
	.Select(x => x.Points)
	.OrderDescending()
	.Sum());

Console.WriteLine("Total score if we are a little sneaky: " + new UltraTopSecretStrategyGuideGamePlan("data.ssv")
	.Execute()
	.Select(x => x.Points)
	.OrderDescending()
	.Sum());
