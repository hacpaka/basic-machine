using BasicMachine.Syntax;

namespace BasicMachine;

public class Machine {
	private readonly Dictionary<int, Instruction> instructions = new();

	public void Register(Instruction instruction) {
		instructions.Add(instruction.Address, instruction);
	}

	public void Run() {
		Console.WriteLine("Machine is running!");

		List<int> flow = instructions.Keys.ToList();
		flow.Sort();

		int count = 0;
		foreach (int index in flow) {
			instructions[index].Execute();

			if (++count > 100) {
				break;
			}
		}
	}
}