using System.Text.RegularExpressions;
using BasicMachine.Parsers;

namespace BasicMachine.Syntax.Lexemes.Abstractions;

public abstract class ACommand: AExecutable {
	protected readonly List<string> Arguments = new();

	public static bool TryToCompile<T>(string raw, ref ACommand command) where T: ACommand, new() {
		if (!TokenParser.Parse(new Regex($"^{typeof(T).Name}", RegexOptions.IgnoreCase), ref raw)) {
			return false;
		}

		command = new T();

		if (raw.Length > 0) {
			command.Arguments.Add(raw);
		}

		return true;
	}

}