
using Jarvis.Core.Actions;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Cognition;
public class OutcomeInterpreter : IOutcomeInterpreter
{
    public ActionResult Interpret(AgentAction action, EnvironmentState prev, EnvironmentState next, TraitProfile traits) {
        // Example: measure novelty as difference in symbols, surprise as unexpected result
        var novelty = prev.Symbols.Zip(next.Symbols, (a, b) => a.Value != b.Value ? 1 : 0).Sum() / (double)prev.Symbols.Count;
        var surprise = action.Type == ActionType.Compare && novelty > 0.5 ? 1.0 : 0.0;
        var learningValue = novelty + 0.5 * surprise;
        return new ActionResult(
            Success: true,
            Outcome: novelty > 0 ? "Changed" : "No Change",
            novelty,
            surprise,
            learningValue,
            $"Compared {action.Targets[0]} and {action.Targets.ElementAtOrDefault(1)}"
        );
    }
}
