using BasicMachine.Commands.Abstractions;

namespace BasicMachine.Commands;

public class Dim: ACommand {
	protected void Parse() {
		throw new NotImplementedException();
	}

	public override void Execute() {

	}

	public Dim(string source): base(source) {}
}