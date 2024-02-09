using BasicMachine.Syntax;
using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine;

public class Machine {
	private readonly Dictionary<int, List<AExecutable>> instructions = new();

	public void Register(Instruction instruction) {
		instructions.Add(instruction.Address, instruction.Commands);
	}

	public void Run() {
		Console.WriteLine("Machine is running!");
	}
}