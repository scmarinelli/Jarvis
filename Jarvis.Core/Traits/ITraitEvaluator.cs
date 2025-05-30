using Jarvis.Core.Actions;
using Jarvis.Core.Memory;

namespace Jarvis.Core.Traits;

public interface ITraitEvaluator
{
    TraitProfile UpdateTraits(TraitProfile current, ActionResult lastResult, MetaCognitiveState meta);
}