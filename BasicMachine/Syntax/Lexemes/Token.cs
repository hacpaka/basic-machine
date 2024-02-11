namespace BasicMachine.Syntax.Lexemes;

public enum EType {
	Float,
	Integer,
	String,
}

public class Token {
	public EType Type {
		get; set;
	}

	public string Content {
		get; private set;
	}

	public Token(EType type, string content) {

	}
}