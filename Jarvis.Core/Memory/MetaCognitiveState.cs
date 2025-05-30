namespace Jarvis.Core.Memory;

public record MetaCognitiveState(
    string CurrentStrategy,                  // e.g. "Explore", "Persist", etc.
    Dictionary<string, double> TraitAdjustments, // History of trait weight tweaks
    double LearningRate,                     // Meta-learning rate, optional
    string? LastInsight
);
