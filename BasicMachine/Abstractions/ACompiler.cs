using BasicMachine.Syntax;

namespace BasicMachine.Abstractions;

public abstract class ACompiler {
	protected StreamReader Reader {
		get;
	}

	protected ACompiler(StreamReader reader) {
		Reader = reader;
	}

	public abstract IEnumerable<Instruction> Compile(int? limit);
}