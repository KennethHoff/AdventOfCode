namespace AdventOfCode.Day04.Models;

internal readonly record struct Assignment(Range Range)
{
	public bool IsFullyEncapsulatedBy(Assignment other)
		=> other.Range.Start.Value <= Range.Start.Value && other.Range.End.Value >= Range.End.Value;

	public bool IsPartiallyEncapsulatedBy(Assignment other)
		=> (other.Range.Start.Value <= Range.Start.Value && other.Range.End.Value >= Range.Start.Value) ||
		   (other.Range.Start.Value <= Range.End.Value && other.Range.End.Value >= Range.End.Value);
}

