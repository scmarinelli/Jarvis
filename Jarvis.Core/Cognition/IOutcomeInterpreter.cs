using Jarvis.Core.Actions;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Cognition;

public interface IOutcomeInterpreter
{
    ActionResult Interpret(AgentAction action, EnvironmentState prev, EnvironmentState next, TraitProfile traits);
}