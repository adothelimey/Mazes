using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Mazes.Algorithms;

public abstract class MazeAlgorithm
{
    public abstract void ExecuteOn(Grid grid, MazeAlgorithmOptions options);

    public class MazeAlgorithmOptions
    {
    }
}

public class MazeAlgorithmOptions<T>
{
    public T Options { get; set; }
}
