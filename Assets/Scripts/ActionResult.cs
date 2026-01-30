public enum ActionResult
{
    Success,            // Valid mask placed on new house
    IllegalMove,        // Clicked on grayed house
    AlreadyVisited,     // repeated mask on same house
    RunEnded            // The run has ended
}