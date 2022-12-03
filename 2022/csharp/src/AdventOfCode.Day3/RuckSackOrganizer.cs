using AdventOfCode.Day3.Models;

namespace AdventOfCode.Day3;

internal sealed class RuckSackOrganizer
{
	private static readonly string RecordDelimiter = Environment.NewLine;

	private readonly string _filePath;

	internal RuckSackOrganizer(string filePath)
	{
		_filePath = filePath;
	}

	internal IReadOnlyCollection<RuckSack> Organize()
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(itemsInSack =>
			{
				var parts = itemsInSack.Chunk(itemsInSack.Length / 2).ToArray();
				var compartment1 = new RuckSackCompartment(parts[0].Select(item => new RuckSackItem(new ItemPriority(item))).ToArray());
				var compartment2 = new RuckSackCompartment(parts[1].Select(item => new RuckSackItem(new ItemPriority(item))).ToArray());
				return new RuckSack(compartment1, compartment2);
			})
			.ToArray();
}

