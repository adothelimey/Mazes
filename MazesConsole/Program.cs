// See https://aka.ms/new-console-template for more information

using TheGrid;
using TheGrid.Mazes.Algorithms;

Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);


var grid = new Grid(10, 10); //6 rows, 3 cols

Console.WriteLine(grid.ToTextDisplay());
Console.ReadKey();

var bt = new BinaryTree();
var opt = new BinaryTreeOptions();
bt.ExecuteOn(grid, opt);
Console.WriteLine(grid.ToTextDisplay());
Console.ReadKey();