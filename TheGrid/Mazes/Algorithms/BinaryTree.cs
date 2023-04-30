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
                            //for now, assume directionbias is an int between 0 and 100 representing the bias distance between DirectionA and DirectionB
                            //When we pick a random neightbour from our neighbourlist, we will use the bias to influence our pick

                            //convert int to double between 0 and 1.0
                            var bias = (double)o.DirectionBias / 100.0;

                            double randomNumber = Random.Shared.NextDouble();
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
                            int minVal = 0;
                            int maxVal = neighboursToChooseFrom.Count -1;
                            int biasedRandomNumber = (int)(randomNumber * (maxVal - minVal + 1)) + minVal;

                            //GridCell luckyWinner = neighboursToChooseFrom[biasedRandomNumber];
                            //if (neighboursToChooseFrom.Count > 1)
                            //{
                            //    luckyWinner = neighboursToChooseFrom[biasedRandomNumber];
                            //}
                            //else
                            //    luckyWinner = neighboursToChooseFrom[0];

                            cell.LinkTo(neighboursToChooseFrom[biasedRandomNumber]);
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
