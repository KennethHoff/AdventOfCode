using AdventOfCode.Day4.Models;

namespace AdventOfCode.Day4.Logic;

internal sealed class OverlappingAssignmentAnalyzer
{
	private const string ValueDelimiter = ",";
	private const string RangeDelimiter = "-";
	private const string RecordDelimiter = "\n";

	private readonly string _filePath;

	public OverlappingAssignmentAnalyzer(string filePath)
	{
		_filePath = filePath;
	}

	public IEnumerable<AssignmentPair> GetAssignments()
		=> File.ReadAllText(_filePath)
			.Split(RecordDelimiter, StringSplitOptions.RemoveEmptyEntries)
			.Select(line =>
			{
				var values = line.Split(ValueDelimiter, StringSplitOptions.RemoveEmptyEntries);
				var (range1, range2) = (CreateRange(values[0]), CreateRange(values[1]));
				var (assignment1, assignment2) = (new Assignment(range1), new Assignment(range2));

				return new AssignmentPair(assignment1, assignment2);
			});

	private static Range CreateRange(string value)
	{
		var range = value.Split(RangeDelimiter, StringSplitOptions.RemoveEmptyEntries);
		return int.Parse(range[0])..int.Parse(range[1]);
	}
}
