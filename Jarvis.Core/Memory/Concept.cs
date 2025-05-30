using Jarvis.Environment;

namespace Jarvis.Core.Memory;

public record Concept(
    string Name,                         // e.g. "Equality", "Symmetry"
    List<Symbol> SymbolsInvolved,        // E.g. [A, B]
    string? Definition,                  // Human-readable or machine-parseable
    double Confidence,                   // How strongly does agent believe in this?
    DateTime CreatedAt
);
