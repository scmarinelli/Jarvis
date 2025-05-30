using Jarvis.Core.Actions;
using Jarvis.Core.Cognition;
using Jarvis.Core.Focus;
using Jarvis.Core.Memory;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core;

public class Agent : IAgent
{
    public AgentState State { get; private set; }

    private readonly ITraitEvaluator traitEvaluator;
    private readonly IFocusSelector focusSelector;
    private readonly IActionSelector actionSelector;
    private readonly IMemoryManager memoryManager;
    private readonly IOutcomeInterpreter outcomeInterpreter;
    private readonly IMetaCognition metaCognition;

    public Agent(
        TraitProfile initialTraits,
        ITraitEvaluator traitEvaluator,
        IFocusSelector focusSelector,
        IActionSelector actionSelector,
        IMemoryManager memoryManager,
        IOutcomeInterpreter outcomeInterpreter,
        IMetaCognition metaCognition) {
        State = new AgentState(
            initialTraits,
            new AgentFocus(null, null, 0.0, 0.0),
            memoryManager.GetCurrentMemory(),
            new MetaCognitiveState("Explore", new(), 1.0, null)
        );
        this.traitEvaluator = traitEvaluator;
        this.focusSelector = focusSelector;
        this.actionSelector = actionSelector;
        this.memoryManager = memoryManager;
        this.outcomeInterpreter = outcomeInterpreter;
        this.metaCognition = metaCognition;
    }

    public void Perceive(EnvironmentState environmentState) {
        memoryManager.UpdateCurrentState(environmentState);
        var focus = focusSelector.SelectFocus(environmentState, State.Traits, State.Memory);
        State = State with { Focus = focus };
        State = State with { Memory = memoryManager.GetCurrentMemory() };
    }

    public AgentAction DecideAction() {
        return actionSelector.DecideAction(
            State.Memory.Working.CurrentState,
            State.Focus,
            State.Traits,
            State.Memory
        );
    }

    public void InterpretOutcome(ActionResult result) {
        // Update traits based on result
        var newTraits = traitEvaluator.UpdateTraits(State.Traits, result, State.MetaState);
        // Update memory with new episode
        var episode = new Episode(
            State.Memory.Working.StepNumber + 1,
            State.Memory.Working.CurrentState,
            State.Memory.Working.LastAction!,
            result,
            newTraits,
            DateTime.UtcNow
        );
        memoryManager.StoreEpisode(episode);
        State = State with {
            Traits = newTraits,
            Memory = memoryManager.GetCurrentMemory()
        };
    }

    public void Reflect() {
        var meta = metaCognition.Reflect(State.MetaState, State.Memory.Episodic, State.Traits);
        State = State with { MetaState = meta };
    }
}
