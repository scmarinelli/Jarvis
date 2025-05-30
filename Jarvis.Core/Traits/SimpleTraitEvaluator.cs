using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Core.Actions;
using Jarvis.Core.Memory;

namespace Jarvis.Core.Traits;

public class SimpleTraitEvaluator : ITraitEvaluator
{
    public TraitProfile UpdateTraits(TraitProfile current, ActionResult lastResult, MetaCognitiveState meta) {
        // Example: Increase curiosity on high novelty, increase boredom on low novelty,
        // increase persistence when surprised
        var curiosity = Math.Clamp(current.Curiosity + 0.2 * lastResult.Novelty - 0.1 * lastResult.BoredomScore(), 0, 1);
        var boredom = Math.Clamp(current.Boredom + 0.15 * (1 - lastResult.Novelty), 0, 1);
        var persistence = Math.Clamp(current.Persistence + 0.1 * lastResult.Surprise, 0, 1);
        return current with { Curiosity = curiosity, Boredom = boredom, Persistence = persistence };
    }
}
public static class ActionResultExtensions
{
    // Dummy implementation, can be refined based on real criteria
    public static double BoredomScore(this ActionResult result) {
        return result.Novelty < 0.2 ? 1 : 0;
    }
}
