using BasicMachine.Syntax.Lexemes.Variables.Abstractions;

namespace BasicMachine.Syntax.Lexemes.Variables;

public class Integer: AVariable<int> {
	public Integer(string name): base(name, 0) {}
}