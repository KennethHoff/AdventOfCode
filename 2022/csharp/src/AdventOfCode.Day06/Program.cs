using System.Text.Json;
using AdventOfCode.Day06.Logic;

Console.WriteLine("Day 6");

Console.WriteLine(JsonSerializer.Serialize(new CommunicationSystemDecoder("data.gg")
	.GetMessages()
	.First()
	.Length));