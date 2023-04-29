using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Mazes.Algorithms;
/// <summary>
/// Consider every cell in the grid.  Pick a random direction from two given directions and make a connection to that cell.  Given directions must both be on different axis
/// </summary>
public class BinaryTree : MazeAlgorithm
{
    public override void ExecuteOn(Grid grid, MazeAlgorithmOptions<BinaryTreeOptions> options)
    {
        BinaryTreeOptions o = options.Options;

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
                        GridCell? north = cell.GetNeighbourInDirection(o.DirectionA);

                        //get east neighbour
                        GridCell? east = cell.GetNeighbourInDirection(o.DirectionB);
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

public class BinaryTreeOptions
{
    public Direction DirectionA { get; set; }
    public Direction DirectionB { get; set; }
}
