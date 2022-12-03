﻿using AdventOfCode.Day2.Logic;

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
