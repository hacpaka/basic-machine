using BasicMachine.Syntax.Lexemes.Variables.Abstractions;

namespace BasicMachine.Syntax.Lexemes.Variables;

public class Float: AVariable<float> {
	public Float(string name): base(name, 0.0f) {}
}