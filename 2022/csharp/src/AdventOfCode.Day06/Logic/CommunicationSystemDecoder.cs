namespace AdventOfCode.Day06.Logic;

internal sealed class CommunicationSystemDecoder
{
	private readonly string _messageStream;

	public CommunicationSystemDecoder(string filePath)
	{
		_messageStream = File.ReadAllText(filePath);
	}

	public IEnumerable<string> GetMessages()
	{
		const int consecutiveCharactersWithNoInternalDuplicates = 4;
		// Find the first message
		// A message ends after a 4-character sequence of different characters

		var imperativeList = new List<char>();
		foreach (var ch in _messageStream)
		{
			imperativeList.Add(ch);
			if (imperativeList.TakeLast(consecutiveCharactersWithNoInternalDuplicates).Distinct().Count() == consecutiveCharactersWithNoInternalDuplicates)
			{
				var message = imperativeList.Select(x => x.ToString()).Aggregate((a, b) => a + b);
				yield return message;
				imperativeList.Clear();
			}
		}
	}
}