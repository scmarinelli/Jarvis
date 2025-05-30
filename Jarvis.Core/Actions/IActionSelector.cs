using Jarvis.Core.Focus;
using Jarvis.Core.Memory;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Actions;

public interface IActionSelector
{
    AgentAction DecideAction(EnvironmentState state, AgentFocus focus, TraitProfile traits, AgentMemory memory);
}