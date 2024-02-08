using BasicMachine.Abstractions;
using BasicMachine.Commands.Abstractions;
using BasicMachine.Parsers;
using BasicMachine.Syntax;

namespace BasicMachine;

public class Compiler: ACompiler {
	public int Index {
		get; private set;
	}

	public string Line {
		get;
		private set;
	} = "";

	public List<string> Collection {
		get;
	} = new();

	public override IEnumerable<Instruction> Compile() {
		Collection.Clear();

		while (!Reader.EndOfStream) {
			Index++;

			try {
				Line = Reader.ReadLine()!;

				if (Line.Trim().Length < 1) {
					continue;
				}

				CommandParser.Parse(Line, (_, raw) => {
					Collection.Add(raw);
				});
			} catch (Exception e) {
				Console.WriteLine($"Parsing error in line {Index}: {e.Message}");
			}

			if (Collection.Count < 1) {
				continue;
			}

			if (!int.TryParse(Collection[0], out int address)) {
				throw new Exception($"Invalid address: {address}!");
			}

			Instruction instruction = new(address);
			foreach (string raw in Collection.Skip(1)) {

				foreach (Type type in types) {

				}
			}

			yield return instruction;
		}
	}

	private readonly List<Type> types = new ();

	private void LoadCommand<T>() {
		foreach (Type type in GetType().Assembly.GetTypes()) {

			if (!type.IsClass || type.IsNotPublic) {
				continue;
			}

			if (!type.IsSubclassOf(typeof(T))) {
				continue;
			}

			types.Add(type);
		}
	}

	public Compiler(StreamReader reader): base(reader) {
		LoadCommand<ACommand>();
	}
}