

namespace AStar
{
    public class Node
    {
        public Grid.GridItemStates State { get; set; }
        public (int x, int y) GridPosition { get; set; }

        public int gCost, hCost;

        public Node Parent;

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
            set
            {
                fCost = value;
            }
        }

        public Node(Grid.GridItemStates state, (int, int) gridPosition)
        {
            State = state;
            GridPosition = gridPosition;
        }
    }
}