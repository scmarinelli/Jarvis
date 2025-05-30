namespace Jarvis.Environment;

public record EnvironmentState(
    List<Symbol> Symbols,             // E.g. [A, B, B, A]
    string? RuleContext               // e.g. "Case-insensitive", for ZPD
);