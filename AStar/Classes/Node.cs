

namespace AStar
{
    public class Node
    {
        public Grid.GridItemStates State { get; set; }
        public (int, int) GridPosition { get; set; }

        public Node(Grid.GridItemStates state, (int, int) gridPosition)
        {
            State = state;
            GridPosition = gridPosition;
        }
    }
}