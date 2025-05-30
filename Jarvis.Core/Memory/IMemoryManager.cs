using Jarvis.Environment;

namespace Jarvis.Core.Memory;

public interface IMemoryManager
{
    void StoreEpisode(Episode episode);
    void UpdateCurrentState(EnvironmentState state);
    void Consolidate();
    void Decay();
    AgentMemory GetCurrentMemory();
}
