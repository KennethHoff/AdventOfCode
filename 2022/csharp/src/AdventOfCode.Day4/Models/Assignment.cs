namespace AdventOfCode.Day4.Models;

internal readonly record struct Assignment(Range Range)
{
	public bool IsFullyEncapsulatedBy(Assignment range)
		=> range.Range.Start.Value <= Range.Start.Value && range.Range.End.Value >= Range.End.Value;
}