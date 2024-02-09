using BasicMachine.Syntax;
using CommandLine;

namespace BasicMachine;

internal class Options {
	public Options(string? target, int limit, bool trace, bool debug) {
		Target = target;
		Limit = limit;
		Trace = trace;
		Debug = debug;
	}

	[Option("target", Required = true, HelpText = "Target BASIC file")]
	public string? Target {
		get;
	}

	[Option("limit", Required = false, HelpText = "Target BASIC file")]
	public int Limit {
		get;
	}

	[Option("trace", Required = false, HelpText = "Show trace")]
	public bool Trace {
		get;
	}

	[Option("debug", Required = false, HelpText = "Show trace")]
	public bool Debug {
		get;
	}
}

internal static class Program {
	private static Machine Machine {
		get;
	} = new();

	private static int Limit {
		get; set;
	}

	private static string? Target {
		get; set;
	}

	private static bool Trace {
		get; set;
	}

	private static bool Debug {
		get; set;
	}

	private static void Main(string[]  args) {
		Parser.Default.ParseArguments<Options>(args)
			.WithParsed(o => {

				if (!File.Exists(o.Target)) {
					throw new Exception($"Invalid target: {o.Target}");
				}

				Target = o.Target;
				Limit = o.Limit;
				Trace = o.Trace;
				Debug = o.Debug;
			});

		Compiler compiler = new(new StreamReader(Target!));
		Console.WriteLine($"Compiling: {Target} ...");
		bool completed = false;

		try {

			foreach (Instruction instruction in compiler.Compile()) {
				if (Limit > 0 && compiler.Index >= Limit) {

					if (Trace) {
						Console.WriteLine("Terminated because of limit reached!");
					}

					break;
				}

				Machine.Register(instruction);
			}

			completed = true;
		} catch (Exception e) {
			Console.WriteLine($"Compilation error on line {compiler.Index}: {e.Message}");

			if (Trace) {
				Console.WriteLine($"Input: `{compiler.Line}`, transliterated as: {{{string.Join("}}, {{", compiler.Collection)}}}");
			}

			if (Debug) {
				throw;
			}
		}

		if (!completed) {
			return;
		}

		Machine.Run();
	}
}