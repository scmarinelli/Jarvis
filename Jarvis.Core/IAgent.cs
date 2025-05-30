using Jarvis.Core.Actions;
using Jarvis.Environment;

namespace Jarvis.Core;

public interface IAgent
{
    AgentState State { get; }
    void Perceive(EnvironmentState environmentState);
    AgentAction DecideAction();
    void InterpretOutcome(ActionResult result);
    void Reflect(); // Meta-cognition
}
