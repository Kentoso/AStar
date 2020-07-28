using System;
using System.Collections.Generic;
using System.IO;

namespace AStar
{
    public class Pathfinding
    {
        public static void FindPath(Grid grid, Node start, Node finish)
        {
            List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(start);
            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];
                for (int i = 0; i < openSet.Count; i++)
                {
                    if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                if (currentNode == finish)
                {
                    CreatePath(grid, start, finish);
                    return;
                }

                foreach (var neighbour in grid.GetNodeNeighbours(currentNode))
                {
                    if (neighbour.State == Grid.GridItemStates.Wall || closedSet.Contains(neighbour))
                    {
 
                        continue;
                    }

                    int neighbourMovementCost = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (neighbourMovementCost < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = neighbourMovementCost;
                        neighbour.hCost = GetDistance(neighbour, finish);
                        neighbour.Parent = currentNode;
                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }

        public static void CreatePath(Grid grid, Node start, Node finish)
        {
            grid.Path = new List<Node>();
            List<Node> path = new List<Node>();
            Node currentNode = finish;
            while (currentNode != start)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            path.Reverse();
            grid.Path = path;
        }
        public static int GetDistance(Node a, Node b)
        {
            int distX = Math.Abs(a.GridPosition.x - b.GridPosition.x);
            int distY = Math.Abs(a.GridPosition.y - b.GridPosition.y);
            if (distX > distY)
            {
                return 14 * distY + 10 * (distX - distY);
            }
            return 14 * distX + 10 * (distY - distX);
        }
    }
}