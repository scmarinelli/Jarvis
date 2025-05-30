using Jarvis.Core.Focus;
using Jarvis.Core.Memory;
using Jarvis.Core.Traits;

namespace Jarvis.Core;

public record AgentState(
    TraitProfile Traits,
    AgentFocus Focus,
    AgentMemory Memory,
    MetaCognitiveState MetaState
);
