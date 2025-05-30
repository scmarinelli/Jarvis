
using Jarvis.Core.Memory;
using Jarvis.Core.Traits;
using Jarvis.Environment;

namespace Jarvis.Core.Focus;

public class NoveltyFocusSelector : IFocusSelector
{
    public AgentFocus SelectFocus(EnvironmentState state, TraitProfile traits, AgentMemory memory) {
        // Example: focus on the symbol with least visits or highest novelty
        var noveltyScores = state.Symbols.Select((symbol, idx) => {
            var novelty = memory.Episodic.Count(ep => ep.State.Symbols[idx].Value == symbol.Value) == 0 ? 1.0 : 0.2;
            return (idx, symbol, novelty);
        }).ToList();

        var best = noveltyScores.OrderByDescending(n => n.novelty + traits.Curiosity * 0.8 - traits.Boredom * 0.4).First();
        return new AgentFocus(best.idx, best.symbol, best.novelty, 1.0);
    }
}
