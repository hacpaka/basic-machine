using System.Text.RegularExpressions;
using BasicMachine.Parsers;

namespace BasicMachine.Syntax.Lexemes.Abstractions;

public abstract class ACommand: AExecutable {
	private List<string> Arguments {
		get;
	} = new();

	public static bool TryToCompile<T>(string raw, ref ACommand command) where T: ACommand, new() {
		if (!TokenParser.Parse(new Regex($"^{typeof(T).Name}", RegexOptions.IgnoreCase), ref raw)) {
			return false;
		}

		command = new T();
		command.Arguments.Add(raw);

		return true;
	}

}