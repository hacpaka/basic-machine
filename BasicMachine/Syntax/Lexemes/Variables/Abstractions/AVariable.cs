using System.Text.RegularExpressions;

namespace BasicMachine.Syntax.Lexemes.Variables.Abstractions;

public abstract class AVariable<T>: IStatemental {

	public string Name {
		get; private set;
	}

	public T Value {
		get; private set;
	}

	protected AVariable(string name, T value) {
		if (!Regex.IsMatch(name, "^[A-Z][A-Z0-9]{0,79}[%$]$", RegexOptions.IgnoreCase)) {
			throw new Exception($"Invalid variable name: {name}");
		}

		Name = name[..2];
		Value = value;
	}
}