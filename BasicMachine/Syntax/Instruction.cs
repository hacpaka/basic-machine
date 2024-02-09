using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine.Syntax;

public class Instruction {
	private readonly List<AExecutable> commands = new();

	public int Address {
		get; private set;
	}

	public Instruction(int address, Action<List<AExecutable>> handler) {
		Address = address;
		handler.Invoke(commands);
	}
}