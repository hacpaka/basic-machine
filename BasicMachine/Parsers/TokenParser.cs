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
		});

		return count > 0;
	}
}