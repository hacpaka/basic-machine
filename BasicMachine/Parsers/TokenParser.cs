using System.Text.RegularExpressions;

namespace BasicMachine.Parsers;

public static class TokenParser {
	public static bool Parse(Regex parser, ref string line) {

		if (line.Trim().Length < 1) {
			throw new Exception("Nothing to parse!");
		}

		int count = 0;

		line = parser.Replace(line, _ => {
			count++;
			return "";
		})
			/*
			 * The extra whitespace characters are insignificant
			 * for BASIC syntax and should be removed.
			 */
			.Trim();

		return count > 0;
	}
}