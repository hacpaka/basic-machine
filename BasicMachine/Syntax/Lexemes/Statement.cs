using BasicMachine.Parsers;
using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine.Syntax.Lexemes;

public class Statement: AExecutable {

	public override void Execute() {
		throw new NotImplementedException();
	}

	public Statement(List<string> parsed) {

	}

	public static bool TryToCompile(string raw, out Statement? statement) {
		statement = null;
		List<string> values = new();

		StatementParser.Parse(raw, (index, match) => {
			// Console.WriteLine($"======> {index} ==> {match}");
			values.Add(match);
		});

		if (values.Count <= 1) {
			return false;
		}

		statement = new Statement(values);
		return true;
	}
}