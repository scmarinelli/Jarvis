using Jarvis.Core.Traits;

namespace Jarvis.Core.Memory;
public record MetaMemory(
    int EpisodeRef,
    string LearningEvent,                // e.g. "Breakthrough", "Boredom Switch"
    TraitProfile TraitsAtEvent,
    string? Reflection,                  // "I learned best when curiosity was high"
    DateTime Timestamp
);
