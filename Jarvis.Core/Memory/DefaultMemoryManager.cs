using Jarvis.Environment;

namespace Jarvis.Core.Memory;

public class MemoryManager : IMemoryManager
{
    private readonly List<Episode> _episodes = new();
    private readonly List<Concept> _concepts = new();
    private readonly List<MetaMemory> _meta = new();
    private WorkingMemory _working = new(new EnvironmentState(new(), null), null, null, 0);

    public void StoreEpisode(Episode episode) {
        _episodes.Add(episode);
        _working = _working with {
            LastAction = episode.Action,
            LastResult = episode.Result,
            StepNumber = episode.StepNumber,
            CurrentState = episode.State
        };
    }

    public void Consolidate() { /* Placeholder: logic for abstracting concepts from episodes */ }
    public void Decay() { /* Placeholder: decay old episodes, manage memory size */ }
    public AgentMemory GetCurrentMemory() =>
        new AgentMemory(_working, _episodes, _concepts, _meta);
}
