using System.Text.RegularExpressions;

namespace BasicMachine.Helpers;

public static class Finder {
	public static bool Find(Regex pattern, string target, Action<int, string> handler) {
		Match result = pattern.Match(target);

		if (!result.Success) {
			return false;
		}

		if (result.Groups.Count < 1) {
			return false;
		}

		for (int i = 0; i < result.Groups.Count; i++) {

			/*
			 * The primary matching group should be ignored if we want to return only subpatterns,
			 * which is expected in most cases.
			 */
			if (i < 1) {
				continue;
			}

			foreach (string match in result.Groups[i].Captures.Select(v => v.Value).ToList()) {
				handler.Invoke(i, match);
			}
		}

		return true;
	}
}