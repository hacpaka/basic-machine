using BasicMachine.Commands.Abstractions;

namespace BasicMachine.Syntax;

public class Instruction {
	public List<ACommand> Commands {
		get;
	} = new();

	public int Address {
		get; private set;
	}

	public Instruction(int address) {
		Address = address;
	}

	public Instruction(int address, List<string> raws): this(address) {
		if (raws.Count > 0) {

		}
	}


}