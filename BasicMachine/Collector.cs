using BasicMachine.Parsers;
using BasicMachine.Syntax;

namespace BasicMachine;


public class Collector {
	private readonly List<string> fragments = new();

	public int Length {
		get {
			return fragments.Count;
		}
	}

	public bool Empty {
		get {
			return Length > 0;
		}
	}

	public void Collect(string fragment) {
		fragments.Add(fragment);
	}

	public Instruction Compile() {
		return new Instruction(10);
	}
}