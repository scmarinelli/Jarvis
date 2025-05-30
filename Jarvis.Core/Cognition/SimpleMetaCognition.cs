using Jarvis.Core.Memory;
using Jarvis.Core.Traits;

namespace Jarvis.Core.Cognition;

public class MetaCognition : IMetaCognition
{
    public MetaCognitiveState Reflect(MetaCognitiveState meta, List<Episode> recentEpisodes, TraitProfile currentTraits) {
        // Simple meta-learning: if many boring episodes, increase curiosity
        var boringCount = recentEpisodes.Count(e => e.TraitSnapshot.Boredom > 0.7);
        var curiosityAdjust = boringCount > 3 ? 0.05 : 0.0;
        var newTraitAdjustments = new Dictionary<string, double>(meta.TraitAdjustments) {
            ["Curiosity"] = meta.TraitAdjustments.GetValueOrDefault("Curiosity", 0.0) + curiosityAdjust
        };
        return meta with {
            TraitAdjustments = newTraitAdjustments,
            LastInsight = boringCount > 3 ? "Increased curiosity due to boredom" : meta.LastInsight
        };
    }
}
