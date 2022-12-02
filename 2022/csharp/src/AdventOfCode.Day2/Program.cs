﻿using AdventOfCode.Day2;

Console.WriteLine("Total score if everything goes according to plan: " + new FileParser("data.ssv")
	.GetScores(false)
	.Select(x => x.Points)
	.OrderDescending()
	.Sum());
	
Console.WriteLine("Total score if we are a little sneaky: " + new FileParser("data.ssv")
	.GetScores(true)
	.Select(x => x.Points)
	.OrderDescending()
	.Sum());