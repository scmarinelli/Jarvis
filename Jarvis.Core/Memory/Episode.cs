using Jarvis.Core.Actions;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Memory;

public record Episode(
    int StepNumber,
    EnvironmentState State,
    AgentAction Action,
    ActionResult Result,
    TraitProfile TraitSnapshot,
    DateTime Timestamp
);
