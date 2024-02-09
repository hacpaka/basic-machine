using BasicMachine.Syntax;
using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine;

public class Machine {
	private readonly Dictionary<int, Instruction> instructions = new();

	public void Register(Instruction instruction) {
		instructions.Add(instruction.Address, instruction);
	}

	public void Run() {
		Console.WriteLine("Machine is running!");
	}
}