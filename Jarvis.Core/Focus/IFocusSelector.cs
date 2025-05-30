using Jarvis.Core.Memory;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Focus;

public interface IFocusSelector
{
    AgentFocus SelectFocus(EnvironmentState state, TraitProfile traits, AgentMemory memory);
}