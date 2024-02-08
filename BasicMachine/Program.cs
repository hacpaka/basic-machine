using BasicMachine.Syntax;
using CommandLine;

namespace BasicMachine;

internal class Options {
	public Options(string? target, bool trace) {
		Target = target;
		Trace = trace;
	}

	[Option("target", Required = true, HelpText = "Target BASIC file")]
	public string? Target {
		get;
	}

	[Option("trace", Required = false, HelpText = "Show trace")]
	public bool Trace {
		get;
	}
}

internal static class Interpreter {
	private static Machine Machine {
		get;
	} = new();

	private static string? Target {
		get; set;
	}

	private static bool Trace {
		get; set;
	}

	private static void Main(string[]  args) {
		Parser.Default.ParseArguments<Options>(args)
			.WithParsed(o => {

				if (!File.Exists(o.Target)) {
					throw new Exception($"Invalid target: {o.Target}");
				}

				Target = o.Target;
				Trace = o.Trace;
			});

		Compiler compiler = new(new StreamReader(Target!));
		Console.WriteLine($"Compiling: {Target} ...");

		try {

			foreach (Instruction instruction in compiler.Compile()) {
				Machine.Register(instruction);
			}
		} catch (Exception e) {
			Console.WriteLine($"Compilation error on line {compiler.Index}: {e.Message}");

			if (Trace) {
				Console.WriteLine($"Input: `{compiler.Line}`, transliterated as: {string.Join(", ", compiler.Collection)}");
			}
		}

		Machine.Run();
	}
}