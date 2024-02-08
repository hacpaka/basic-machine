using BasicMachine.Commands.Abstractions;
using BasicMachine.Syntax;

namespace BasicMachine;

public class Machine {
	private readonly Dictionary<int, List<ACommand>> instructions = new();

	public void Register(Instruction instruction) {
		instructions.Add(instruction.Address, instruction.Commands);
	}

	public void Run() {
		Console.WriteLine("Machine is running!");
	}
}