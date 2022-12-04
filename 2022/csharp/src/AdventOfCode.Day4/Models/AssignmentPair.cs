namespace AdventOfCode.Day4.Models;

internal sealed record class AssignmentPair(Assignment Assignment1, Assignment Assignment2)
{
	public bool IsFullyOverlapping => Assignment1.IsFullyEncapsulatedBy(Assignment2) || Assignment2.IsFullyEncapsulatedBy(Assignment1);
	
	public bool IsPartiallyOverlapping => Assignment1.IsPartiallyEncapsulatedBy(Assignment2) || Assignment2.IsPartiallyEncapsulatedBy(Assignment1);
}