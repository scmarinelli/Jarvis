using Jarvis.Core.Focus;
using Jarvis.Core.Memory;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Actions;

public class SimpleActionSelector : IActionSelector
{
    private static readonly Random Rng = new();

    public AgentAction DecideAction(EnvironmentState state, AgentFocus focus, TraitProfile traits, AgentMemory memory) {
        // Example: if curiosity is high, try COMPARE or a random action; if persistence is high, repeat last action
        if (traits.Curiosity > 0.7) {
            var idx2 = Rng.Next(state.Symbols.Count);
            return new AgentAction(ActionType.Compare, new[] { focus.FocusIndex!.Value, idx2 }, "Curiosity-driven compare");
        }
        else if (traits.Persistence > 0.7 && memory.Working.LastAction != null) {
            return memory.Working.LastAction;
        }
        else {
            return new AgentAction(ActionType.NoOp, Array.Empty<int>(), "NoOp");
        }
    }
}
