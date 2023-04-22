using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid.Pathfinding;

public class Distances
{
    public GridCell RootCell { get; private set; }
    public Dictionary<GridCell, int> CellsAndTheirDistanceFromRoot { get; private set; }

    public Distances(GridCell root)
    {
        RootCell = root;
        CellsAndTheirDistanceFromRoot = new Dictionary<GridCell, int>{{ RootCell, 0 }};
    }
    public int GetDistanceFrom(GridCell cell)
    {
        int distance = 0;

        if(CellsAndTheirDistanceFromRoot.ContainsKey(cell))
        {
            distance = CellsAndTheirDistanceFromRoot[cell];
        }

        return distance;
    }

    public void AddCell(GridCell cell, int distance)
    {
        CellsAndTheirDistanceFromRoot.Remove(cell);
        CellsAndTheirDistanceFromRoot.Add(cell, distance);
    }

    public Distances PathTo(GridCell cell)
    {
        var currentCell = cell;

        var breadcrumbs = new Distances(RootCell);
        breadcrumbs.AddCell(currentCell, GetDistanceFrom(currentCell));

        while (currentCell != RootCell) {
            foreach (var neighbour in currentCell.LinkedNeighbours)
            {
                if (CellsAndTheirDistanceFromRoot[neighbour] < CellsAndTheirDistanceFromRoot[currentCell])
                {
                        breadcrumbs.AddCell(neighbour, GetDistanceFrom(neighbour));
                        currentCell = neighbour;
                        break;
                }
            }
        }

        return breadcrumbs;
    }

    public KeyValuePair<GridCell, int> FurthestCellFromRoot()
    {
        var maxDistance = 0;
        var maxCell = RootCell;

        foreach(var cell in CellsAndTheirDistanceFromRoot)
        {
            if (cell.Value > maxDistance)
            {
                maxCell = cell.Key;
                maxDistance = cell.Value;
            }
        }

        return new KeyValuePair<GridCell, int>(maxCell, maxDistance);
    }


}
