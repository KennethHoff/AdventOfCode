using AdventOfCode.Day07.Models.Commands;

namespace AdventOfCode.Day07.Logic;

internal interface ICommandDecipherer
{
	IEnumerable<ICommand> GetAll();
}

internal sealed class StringDecipheringCommandDecipherer : ICommandDecipherer
{
	private readonly IReadOnlyList<string> _lines;

	public StringDecipheringCommandDecipherer(IReadOnlyList<string> lines)
	{
		_lines = lines;
	}

	public IEnumerable<ICommand> GetAll()
	{
		for (var i = 0; i < _lines.Count; i++)
		{
			var line = _lines[i];

			ICommand command;
			switch (line.Split(' '))
			{
				case ["$", "ls"]:
					var nonCommandsInARow = _lines
						.Skip(i + 1)
						.TakeWhile(l => !l.StartsWith("$"))
						.ToArray();

					command = new ListCommand(nonCommandsInARow);
					i += nonCommandsInARow.Length;
					break;
				case ["$", "cd", { } directory]:
					command = new ChangeDirectoryCommand(directory);
					break;
				default:
					command = new DoNothingCommand();
					break;
			}

			yield return command;
		}
	}
}
