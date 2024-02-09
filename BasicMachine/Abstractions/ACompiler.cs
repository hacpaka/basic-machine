using BasicMachine.Syntax;

namespace BasicMachine.Abstractions;

public abstract class ACompiler {
	private StreamReader Reader {
		get;
	}

	public int Index {
		get; private set;
	}

	public string Line {
		get; private set;
	} = "";

	protected bool Read() {
		if (Reader.EndOfStream) {
			return false;
		}

		Line = Reader.ReadLine()!.Trim();
		Index++;

		if (Line.Length < 1) {
			return Read();
		}

		return true;
	}

	protected ACompiler(StreamReader reader) {
		Reader = reader;
	}

	public abstract IEnumerable<Instruction> Compile();
}