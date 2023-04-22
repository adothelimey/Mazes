using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Pathfinding
{
    public static class GridCellDistanceExtentions
    {
        public static Distances GetDistances(this GridCell cell) {

            var distances = new Distances(cell);
            var frontier = new List<GridCell>();
            frontier.Add(cell);

            while (frontier.Any()) {
                var newFrontier = new List<GridCell>();

                foreach (var frontierCell in frontier)
                {
                    foreach(var linkedCell in frontierCell.LinkedNeighbours)
                    {
                        if (!distances.CellsAndTheirDistanceFromRoot.ContainsKey(linkedCell))
                        {
                            distances.AddCell(linkedCell, distances.GetDistanceFrom(frontierCell) + 1);
                            newFrontier.Add(linkedCell);
                        }
                    }
                }

                frontier = newFrontier;
            }

            return distances;
        }

    }
}
