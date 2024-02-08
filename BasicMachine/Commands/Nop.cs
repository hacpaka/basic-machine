using BasicMachine.Commands.Abstractions;

namespace BasicMachine.Commands;

public class Nop: ACommand {
	protected void Parse() {
		throw new NotImplementedException();
	}

	public override void Execute() {

	}

	public Nop(): base(null) {}
}