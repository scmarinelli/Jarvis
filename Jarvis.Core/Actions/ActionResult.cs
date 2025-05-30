namespace Jarvis.Core.Actions;

public record ActionResult(
    bool Success,
    string Outcome,                   // "Same", "Different", "Unexpected", etc.
    double Novelty,
    double Surprise,
    double LearningValue,             // Intrinsic value computed from outcome
    string? AdditionalInfo
);
