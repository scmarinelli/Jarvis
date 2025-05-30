using Jarvis.Core.Actions;
using Jarvis.Environment;

namespace Jarvis.Core.Memory;

public record WorkingMemory(
    EnvironmentState CurrentState,
    AgentAction? LastAction,
    ActionResult? LastResult,
    int StepNumber
);
