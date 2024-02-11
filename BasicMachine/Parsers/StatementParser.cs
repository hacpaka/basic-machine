using System.Text.RegularExpressions;
using BasicMachine.Helpers;

namespace BasicMachine.Parsers;

public static class StatementParser {
	public static void Parse(string line, Action<int, string> handler) {

		if (line.Trim().Length < 1) {
			throw new Exception("Nothing to parse!");
		}

		if (!Finder.Find(new Regex(@"^([a-z0-9]+)((?:[$%]|\((?:[a-z0-9]+,?)+\)))?\s*=\s*(.+)$", RegexOptions.IgnoreCase), line,
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