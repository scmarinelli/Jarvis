using Jarvis.Environment;

namespace Jarvis.Core.Focus;

public record AgentFocus(
    int? FocusIndex,              // Position in the environment, if applicable
    Symbol? FocusSymbol,          // What is being attended to
    double NoveltyScore,          // How new/surprising this focus is
    double AttentionStrength      // Degree of attention allocated
);
