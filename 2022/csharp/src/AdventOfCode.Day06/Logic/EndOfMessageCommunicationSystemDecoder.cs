namespace AdventOfCode.Day06.Logic;


internal interface ICommunicationSystemDecoder
{
	IEnumerable<string> GetMessages();
}


internal sealed class EndOfMessageCommunicationSystemDecoder : ICommunicationSystemDecoder
{
	private readonly string _messageStream;

	public EndOfMessageCommunicationSystemDecoder(string filePath)
	{
		_messageStream = File.ReadAllText(filePath);
	}

	public IEnumerable<string> GetMessages()
	{
		// a Marker is defined by X distinct characters in a row
		const int endOfMessageMarkerCount = 4;

		var imperativeList = new List<char>();
		foreach (var ch in _messageStream)
		{
			imperativeList.Add(ch);
			if (imperativeList.TakeLast(endOfMessageMarkerCount).Distinct().Count() == endOfMessageMarkerCount)
			{
				var message = imperativeList.Select(x => x.ToString()).Aggregate((a, b) => a + b);
				yield return message;
				imperativeList.Clear();
			}
		}
	}
}

internal sealed class StartOfMessageCommunicationSystemDecoder : ICommunicationSystemDecoder
{
	private readonly string _messageStream;

	public StartOfMessageCommunicationSystemDecoder(string filePath)
	{
		_messageStream = File.ReadAllText(filePath);
	}

	public IEnumerable<string> GetMessages()
	{
		// a Marker is defined by X distinct characters in a row
		const int startOfMessageMarkerCount = 14;

		var imperativeList = new List<char>();
		foreach (var ch in _messageStream)
		{
			imperativeList.Add(ch);
			if (imperativeList.TakeLast(startOfMessageMarkerCount).Distinct().Count() == startOfMessageMarkerCount)
			{
				var message = imperativeList.Select(x => x.ToString()).Aggregate((a, b) => a + b);
				yield return message;
				imperativeList.Clear();
			}
		}
	}
}