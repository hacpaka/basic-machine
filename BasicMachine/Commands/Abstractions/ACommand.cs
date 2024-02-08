using System.Reflection;
using BasicMachine.Parsers;

namespace BasicMachine.Commands.Abstractions;

public abstract class ACommand {
	private string Source {
		get;
	}

	protected ACommand(string? source) {
		Source = source!;
	}


	public static bool TryToCompile(string raw, out ACommand command) {
		Console.WriteLine($">>>>>>>>> {MethodBase.GetCurrentMethod()!.DeclaringType}");
		// if (!TokenParser.Parse($"^{typ}"))
		command = new Nop();
		return false;
	}

	public abstract void Execute();
}