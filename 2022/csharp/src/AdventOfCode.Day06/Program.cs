using AdventOfCode.Day06.Logic;

Console.WriteLine("Day 6");

Console.WriteLine("End of message marker count: " + new EndOfMessageCommunicationSystemDecoder("data.gg")
	.GetMessages()
	.First()
	.Length);

Console.WriteLine("Start of message marker count: " + new StartOfMessageCommunicationSystemDecoder("data.gg")
	.GetMessages()
	.First()
	.Length);
