namespace Jarvis.Core.Memory;

public interface IMemoryManager
{
    void StoreEpisode(Episode episode);
    void Consolidate();
    void Decay();
    AgentMemory GetCurrentMemory();
}