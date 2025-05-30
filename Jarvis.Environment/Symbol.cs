namespace Jarvis.Environment;

public record Symbol(
    string Value,
    Dictionary<string, string>? Attributes = null   // For extensibility (color, type, etc.)
);