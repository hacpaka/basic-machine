using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine.Syntax.Lexemes.Commands;

public class Stop: ACommand {
	public override void Execute() {
		throw new NotImplementedException();
	}
}