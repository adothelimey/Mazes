using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    public class Grid
    {
        public int Rows { get; set; }
        public int Columns{ get; set; }

        private GridCell[,] GridCells { get; set; }
        public GridCell? GetCellAt(int x, int y)
        {
            GridCell? cell = null;

            if (x >= 0 && y >=0 && x < Columns && y < Rows)
            {
                cell = GridCells[x, y];

            }

            return cell;
        }

        public GridCell GetRandomCell()
        {
            var x = Random.Shared.Next(0, Columns);
            var y = Random.Shared.Next(0, Rows);
            return GridCells[x, y];
        }


        public List<GridCell> GetRow(int rowIndex)
        {
            var row = new List<GridCell>();

            for(var x = 0; x < Columns; x++)
            {
                for(var y = 0;y < Rows; y++)
                {
                    if(y == rowIndex)
                    {
                        row.Add(GridCells[x, y]);
                    }
                }
            }

            return row;
        }
        public List<GridCell> GetColumn(int columnIndex)
        {
            var col = new List<GridCell>();

            for (var x = 0; x < Columns; x++)
            {
                for (var y = 0; y < Rows; y++)
                {
                    if (x == columnIndex)
                    {
                        col.Add(GridCells[x, y]);
                    }
                }
            }

            return col;
        }

        public Grid(int rows, int columns) {
            Rows = rows;
            Columns = columns;
            GridCells = new GridCell[Columns, Rows];

            initialiseGrid();
            initialiseCells();
        
        }

        public int Size()
        {
            return Rows * Columns;
        }

        private void initialiseGrid()
        {
            for(var x = 0; x < Columns; x++)
            {
                for(var  y = 0; y < Rows; y++) {
                    var cell = new GridCell(x, y);
                    GridCells[x, y] = cell;
                }
            }
        }

        private void initialiseCells()
        {
            for (var x = 0; x < Columns; x++)
            {
                for (var y = 0; y < Rows; y++)
                {
                    var cell = GetCellAt(x, y);

                    if (cell != null)
                    {
                        //get and set north neighbour
                        if (y > 0)
                        {
                            var northNeighbour = GridCells[x, y - 1];
                            if (northNeighbour != null) cell.Neighbours.Add(Direction.North, northNeighbour);
                        }
                        //get and set east neighbour
                        if (x < Columns - 1)
                        {
                            var eastNeighbour = GridCells[x + 1, y];
                            if (eastNeighbour != null) cell.Neighbours.Add(Direction.East, eastNeighbour);
                        }
                        //get and set south neighbour
                        if (y < Rows - 1)
                        {
                            var southNeighbour = GridCells[x, y + 1];
                            if (southNeighbour != null) cell.Neighbours.Add(Direction.South, southNeighbour);
                        }
                        //get and set west neighbour
                        if (x > 0)
                        {
                            var westNeighbour = GridCells[x - 1, y];
                            if (westNeighbour != null) cell.Neighbours.Add(Direction.West, westNeighbour);
                        }
                    }
                }
            }
        }

    }
}
