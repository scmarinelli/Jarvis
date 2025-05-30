using Jarvis.Core.Memory;
using Jarvis.Core.Traits;

namespace Jarvis.Core.Cognition;

public interface IMetaCognition
{
    MetaCognitiveState Reflect(MetaCognitiveState meta, List<Episode> recentEpisodes, TraitProfile currentTraits);
}