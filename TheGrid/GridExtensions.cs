using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    public static class GridExtensions
    {
        public static string ToTextDisplay(this Grid grid)
        {
            var s = new StringBuilder();

            for (var y = 0; y < grid.Rows; y++)
            {
                string rowStringTop = "";
                string rowStringMiddle = "";
                string rowStringBottom = "";

                for (var x = 0; x < grid.Columns;x++)
                {
                    var cell = grid.GetCellAt(x, y);

                    if (cell != null)
                    {
                        //000
                        //-0-
                        //---
                        //|0|

                        var b = '+';
                        var o = 'o';

                        var cellStringTop = $"{b}{b}{b}";
                        var cellStringMiddle = $"{b}{o}{b}";
                        var cellStringBottom = $"{b}{b}{b}";

                        bool hasNorthConnection = cell.HasLinkedNeighbourInDirection(Direction.North);
                        bool hasEastConnection = cell.HasLinkedNeighbourInDirection(Direction.East);
                        bool hasSouthConnection = cell.HasNeighbourInDirection(Direction.South);
                        bool hasWestConnection = cell.HasLinkedNeighbourInDirection(Direction.South);                        

                        
                        if (!hasNorthConnection && hasEastConnection && hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{o}{o}{o}";
                            cellStringBottom = $"{b}{o}{b}";
                        }
                        if (hasNorthConnection && !hasEastConnection && hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{o}{o}{b}";
                            cellStringBottom = $"{b}{o}{b}";
                        }
                        if (hasNorthConnection && hasEastConnection && !hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{o}{o}{o}";
                            cellStringBottom = $"{b}{b}{b}";
                        }
                        if (hasNorthConnection && hasEastConnection && hasSouthConnection && !hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{b}{o}{o}";
                            cellStringBottom = $"{b}{o}{b}";
                        }

                        if (!hasNorthConnection && !hasEastConnection && hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{o}{o}{b}";
                            cellStringBottom = $"{b}{o}{b}";
                        }
                        if (!hasNorthConnection && hasEastConnection && hasSouthConnection && !hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{b}{o}{o}";
                            cellStringBottom = $"{b}{o}{b}";
                        }
                        if (hasNorthConnection && hasEastConnection && !hasSouthConnection && !hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{b}{o}{o}";
                            cellStringBottom = $"{b}{b}{b}";
                        }
                        if (hasNorthConnection && !hasEastConnection && !hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{o}{o}{b}";
                            cellStringBottom = $"{b}{b}{b}";
                        }
                        if (hasNorthConnection && !hasEastConnection && hasSouthConnection && !hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{b}{o}{b}";
                            cellStringBottom = $"{b}{o}{b}";
                        }
                        if (!hasNorthConnection && hasEastConnection && !hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{o}{o}{o}";
                            cellStringBottom = $"{b}{b}{b}";
                        }


                        if (!hasNorthConnection && !hasEastConnection && !hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{o}{o}{b}";
                            cellStringBottom = $"{b}{b}{b}";
                        }
                        if (!hasNorthConnection && !hasEastConnection && hasSouthConnection && !hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{b}{o}{b}";
                            cellStringBottom = $"{b}{o}{b}";
                        }
                        if (!hasNorthConnection && hasEastConnection && !hasSouthConnection && !hasWestConnection)
                        {
                            cellStringTop = $"{b}{b}{b}";
                            cellStringMiddle = $"{b}{o}{o}";
                            cellStringBottom = $"{b}{b}{b}";
                        }
                        if (hasNorthConnection && !hasEastConnection && !hasSouthConnection && hasWestConnection)
                        {
                            cellStringTop = $"{b}{o}{b}";
                            cellStringMiddle = $"{b}{o}{b}";
                            cellStringBottom = $"{b}{b}{b}";
                        }








                        rowStringTop += cellStringTop;
                        rowStringMiddle += cellStringMiddle;
                        rowStringBottom += cellStringBottom;

                    }

                }

                s.AppendLine(rowStringTop);
                s.AppendLine(rowStringMiddle);
                s.AppendLine(rowStringBottom);
            }



            return s.ToString();
        }
    }
}
