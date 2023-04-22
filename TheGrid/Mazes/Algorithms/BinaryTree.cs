using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Mazes.Algorithms;

public class BinaryTree : MazeAlgorithm
{
    public override void ExecuteOn(Grid grid)
    {
        if (grid != null)
        {
            //1 - foreach cell in grid
            for (var x = 0; x < grid.Columns; x++)
            {
                for (var y = 0; y < grid.Rows; y++)
                {
                    var cell = grid.GetCellAt(x, y);
                    List<GridCell> neighboursToChooseFrom = new List<GridCell>();
                    if (cell != null)
                    {
                        //get north neighbour
                        GridCell? north = cell.GetNeighbourInDirection(Direction.North);

                        //get east neighbour
                        GridCell? east = cell.GetNeighbourInDirection(Direction.East);
                        if (north != null) neighboursToChooseFrom.Add(north);
                        if (east != null) neighboursToChooseFrom.Add(east);

                        if (neighboursToChooseFrom.Any())
                        {
                            var luckyWinner = neighboursToChooseFrom[Random.Shared.Next(0, neighboursToChooseFrom.Count)];
                            cell.LinkTo(luckyWinner);
                        }
                    }
                }
            }
        }
    }

}
