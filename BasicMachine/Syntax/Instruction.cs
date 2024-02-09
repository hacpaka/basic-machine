using BasicMachine.Commands.Abstractions;

namespace BasicMachine.Syntax;

public class Instruction {
	public List<AExecutable> Commands {
		get;
	} = new();

	public int Address {
		get; private set;
	}

	public Instruction(int address) {
		Address = address;
	}
}