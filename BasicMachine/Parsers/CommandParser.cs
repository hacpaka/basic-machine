using System.Text.RegularExpressions;

namespace BasicMachine.Parsers;

public static class CommandParser {
	public static void Parse(string line, Action<int, string> handler, bool debug = false) {

		if (line.Trim().Length < 1) {
			throw new Exception("Nothing to parse!");
		}

		if (debug) {
			Console.WriteLine($"=> {line}");
		}

		if (!RegexParser.Parse(new Regex(@"^\s*([0-9]+)\s+(?:((?:""[^""]*""|[^:""]+)+):?)+$", RegexOptions.IgnoreCase), line,
				(i, matches) => {

					foreach (string match in matches) {
						handler.Invoke(i, match);

						if (debug) {
							Console.WriteLine($"-> {i}: {match}");
						}
					}
				})) {

			/*
			 * A classic Basic string should contain a list of commands
			 * led by a string number.
			 */
			throw new Exception("Invalid syntax!");
		}
	}
}