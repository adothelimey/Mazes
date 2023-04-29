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
    public override void ExecuteOn(Grid grid, IMazeAlgorithmOptions options)
    {        
        BinaryTreeOptions o = (BinaryTreeOptions)options;

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
                        GridCell? A = cell.GetNeighbourInDirection(o.DirectionA);

                        //get east neighbour
                        GridCell? B = cell.GetNeighbourInDirection(o.DirectionB);
                        if (A != null) neighboursToChooseFrom.Add(A);
                        if (B != null) neighboursToChooseFrom.Add(B);

                        if (neighboursToChooseFrom.Any())
                        {
                            var bias = (double)o.DirectionBias / 100.0;

                            double randomNumber = Random.Shared.NextDouble();
                            
                            GridCell luckyWinner = null;

                            if (randomNumber < bias)
                            {
                                //favour lower numbers
                                randomNumber /= bias;
                            }
                            else
                            {
                                //favour higher numbers
                                randomNumber = (randomNumber - bias) / (1 - bias);                                
                            }
                            int minVal = 1;
                            int maxVal = neighboursToChooseFrom.Count();
                            int biasedRandomNumber = (int)(randomNumber * (maxVal - minVal + 1)) + minVal;

                            if (neighboursToChooseFrom.Count > 1)
                            {
                                luckyWinner = neighboursToChooseFrom[biasedRandomNumber - 1];
                            }
                            else
                                luckyWinner = neighboursToChooseFrom[0];

                            cell.LinkTo(luckyWinner);
                        }
                    }
                }
            }
        }
    }
}

public class BinaryTreeOptions : IMazeAlgorithmOptions
{
    public Direction DirectionA { get; set; }
    public Direction DirectionB { get; set; }

    public int DirectionBias { get; set; }
}
