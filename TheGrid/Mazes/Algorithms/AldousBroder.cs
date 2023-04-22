using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Mazes.Algorithms;

public class AldousBroder : MazeAlgorithm
{
    public override void ExecuteOn(Grid grid)
    {
        var randomCell = grid.GetRandomCell();
        var numOfUnvisitedGridCells = grid.Size() - 1;
        
        while (numOfUnvisitedGridCells > 0)
        {
            var randomNeighbour = randomCell.GetRandomNeighbour();

            if (!randomNeighbour.LinkedNeighbours.Any())
            {
                randomCell.LinkTo(randomNeighbour);
                numOfUnvisitedGridCells -= 1;
            }

            randomCell = randomNeighbour;
        }
    
    }
}
