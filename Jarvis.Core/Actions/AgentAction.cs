namespace Jarvis.Core.Actions;

public record AgentAction(
    ActionType Type,
    int[] Targets,                // e.g. symbol indices
    string? Description           // Optional for logs/debugging
);

public enum ActionType
{
    Compare,
    Swap,
    Group,
    Simulate,     // Internal simulation/imagination
    NoOp
}
