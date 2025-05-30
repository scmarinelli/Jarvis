namespace Jarvis.Core.Memory;

public record AgentMemory(
    WorkingMemory Working,
    List<Episode> Episodic,
    List<Concept> Concepts,
    List<MetaMemory> Meta
);
