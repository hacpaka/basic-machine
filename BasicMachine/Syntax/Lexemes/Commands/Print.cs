using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine.Syntax.Lexemes.Commands;

public class Print: ACommand {
	public override void Execute() {
		if (Arguments.Count < 1) {
			Console.WriteLine();
		} else {

			foreach (string argument in Arguments) {
				Console.WriteLine(argument);
			}
		}
	}
}