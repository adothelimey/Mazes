using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Mazes.Algorithms;

public class Sidewinder : MazeAlgorithm
{
    public override void ExecuteOn(Grid grid)
    {
        if (grid != null)
        {
            for (var rowIndex = 0; rowIndex < grid.Rows; rowIndex++)
            {
                var row = grid.GetRow(rowIndex);

                if (row.Any())
                {
                    var run = new List<GridCell>();

                    for (var i = 0; i < row.Count; i++)
                    {
                        var cell = row[i];
                        run.Add(cell);

                        var atEasternBoundary = !cell.HasNeighbourInDirection(Direction.East);
                        var atNorthernBoundary = !cell.HasNeighbourInDirection(Direction.North);

                        var shouldCloseOut = atEasternBoundary || (!atNorthernBoundary && Random.Shared.Next(0, 2) == 0);

                        if (shouldCloseOut)
                        {
                            var chosenCell = run[Random.Shared.Next(0, run.Count)];
                            if (chosenCell.HasNeighbourInDirection(Direction.North))
                                chosenCell.LinkTo(chosenCell.Neighbours[Direction.North]);
                            run.Clear();
                        }
                        else
                        {
                            cell.LinkTo(cell.Neighbours[Direction.East]);
                        }
                    }
                }
            }
        }
    }
}
