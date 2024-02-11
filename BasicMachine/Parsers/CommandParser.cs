using System.Text.RegularExpressions;
using BasicMachine.Helpers;

namespace BasicMachine.Parsers;

public static class CommandParser {
	public static void Parse(string line, Action<int, string> handler) {

		if (line.Trim().Length < 1) {
			throw new Exception("Nothing to parse!");
		}

		if (!Finder.Find(new Regex(@"^([0-9]+)\s+(?:(REM\s+.*)|((?:""[^""]*""|[^:""]+)+):?)+$", RegexOptions.IgnoreCase), line,
				(i, matches) => {
					handler.Invoke(i, matches);
				})) {

			/*
			 * A classic Basic string should contain a list of commands
			 * led by a string number.
			 */
			throw new Exception("Invalid syntax!");
		}
	}
}