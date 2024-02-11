using BasicMachine.Syntax.Lexemes.Variables.Abstractions;

namespace BasicMachine.Syntax.Lexemes.Variables;

public class String: AVariable<string> {
	public String(string name): base(name, "") {}
}