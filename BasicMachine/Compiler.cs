using System.Reflection;
using BasicMachine.Abstractions;
using BasicMachine.Parsers;
using BasicMachine.Syntax;
using BasicMachine.Syntax.Lexemes;
using BasicMachine.Syntax.Lexemes.Abstractions;

namespace BasicMachine;

public class Compiler: ACompiler {

	public List<string> Collection {
		get;
	} = new();

	public override IEnumerable<Instruction> Compile() {
		while (Read()) {
			Collection.Clear();

			CommandParser.Parse(Line, (_, raw) => {
				Collection.Add(raw);
			});

			if (Collection.Count < 1) {
				continue;
			}

			if (!int.TryParse(Collection[0], out int address)) {
				throw new Exception($"Invalid address: {address}!");
			}

			Instruction instruction = new(address);
			foreach (string raw in Collection.Skip(1)) {

				ACommand command = TryCompileCommand(raw);
				if (command is not Nop) {

					instruction.Commands.Add(command);
					continue;
				}

				AExecutable? statement = TryToCompileStatement(raw);
				if (statement != null) {

					instruction.Commands.Add(statement);
					continue;
				}

				throw new Exception($"Undefined command: {string.Concat(raw.Take(12))}...");
			}

			yield return instruction;
		}
	}

	private AExecutable? TryToCompileStatement(string raw) {
		return null;
	}

	private ACommand TryCompileCommand(string raw) {
		object[] args = { raw, new Nop() };

		foreach (Type type in types) {
			if ((bool)type.GetMethod("TryToCompile",
					BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static)!

				.MakeGenericMethod(type)
				.Invoke(null, args)!) {

				break;
			}
		}

		return (args[1] as ACommand)!;
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