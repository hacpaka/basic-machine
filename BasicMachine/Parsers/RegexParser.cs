using System.Text.RegularExpressions;

namespace BasicMachine.Parsers;

public static class RegexParser {
	public static bool Parse(Regex parser, string target, Action<int, List<string>> handler, bool ignorePrimaryGroup = true) {
		Match result = parser.Match(target);

		if (!result.Success) {
			return false;
		}

		if (result.Groups.Count < 1) {
			return false;
		}

		for (int i = 0; i < result.Groups.Count; i++) {

			/*
			 * The primary matching group should be ignored if we want to return only subpatterns.
			 * Such behavior is expected in most of the cases.
			 */
			if (i < 1 && ignorePrimaryGroup) {
				continue;
			}

			handler(i, result.Groups[i].Captures.Select(v => v.Value).ToList());
		}

		return true;
	}
}