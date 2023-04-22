using System.Diagnostics;
using System.Drawing.Imaging;
using TheGrid;
using TheGrid.Mazes.Algorithms;
using TheGrid.Pathfinding;

namespace MazesForms;
public partial class MazeForm : Form
{
    Grid? grid { get; set; }
    MazeSettings currentMazeSettings = null;
    int magicNumber = 12;

    public MazeForm()
    {
        InitializeComponent();
        cboAlgoSelector.SelectedIndex = 0;
    }

    private void btn_New_Click(object sender, EventArgs e)
    {
        //creates new grid with specified parameters (grid size, line width and colour etc)
        currentMazeSettings = new MazeSettings
        {
            NumberOfRows = (int)num_GridHeight.Value,
            NumberOfColumns = (int)numGridWidth.Value,
            CellWidth = (int)numCellWidth.Value,
            CellHeight = (int)numCellHeight.Value,
            AlgoIndex = cboAlgoSelector.SelectedIndex
        };
        grid = new Grid(currentMazeSettings.NumberOfRows, currentMazeSettings.NumberOfColumns);

        MazeAlgorithm algo = currentMazeSettings.AlgoIndex switch
        {
            2 => new AldousBroder(),
            1 => new Sidewinder(),
            _ => new BinaryTree(),
        };

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        algo.ExecuteOn(grid);
        stopWatch.Stop();
        toolStripStatusLabel1.Text = $"Maze generation took {stopWatch.ElapsedTicks} ticks";

        panel_Draw.AutoScroll = false;
        panel_Draw.Size = new Size(grid.Columns * currentMazeSettings.CellWidth, grid.Rows * currentMazeSettings.CellHeight);
        panel_Draw.AutoScroll = true;
        panel_Draw.Invalidate();
    }

    private void drawGrid(Graphics graphics)
    {
        if (grid != null)
        {
            var rootCell = grid.GetCellAt(0, 0);

            var distances = rootCell.GetDistances();

            //distances = distances.PathTo(rootCell2);

            //var furtherstCell = distances.FurthestCellFromRoot();
            //var newDistances = furtherstCell.Key.GetDistances();
            //var goalCell = newDistances.FurthestCellFromRoot();

            //distances = newDistances.PathTo(goalCell.Key);



            for (var x = 0; x < grid.Columns; x++)
            {
                for (var y = 0; y < grid.Rows; y++)
                {
                    var xPos = x * currentMazeSettings.CellWidth;
                    var yPos = y * currentMazeSettings.CellHeight;

                    var northRect = new Rectangle(xPos, yPos, currentMazeSettings.CellWidth, currentMazeSettings.CellHeight / magicNumber);
                    var eastRect = new Rectangle(xPos + (currentMazeSettings.CellWidth - (currentMazeSettings.CellWidth / magicNumber)), yPos, currentMazeSettings.CellWidth / magicNumber, currentMazeSettings.CellHeight);
                    var southRect = new Rectangle(xPos, yPos + (currentMazeSettings.CellHeight - (currentMazeSettings.CellHeight / magicNumber)), currentMazeSettings.CellWidth, currentMazeSettings.CellHeight / magicNumber);
                    var westRect = new Rectangle(xPos, yPos, currentMazeSettings.CellWidth / magicNumber, currentMazeSettings.CellHeight);

                    var cell = grid.GetCellAt(x, y);


                    var farthestCell = distances.FurthestCellFromRoot();

                    if (cell != null)
                    {
                        if (distances.CellsAndTheirDistanceFromRoot.TryGetValue(cell, out int value))
                        {
                            var distance = value;
                            var shadeColour = Color.Green;

                            var distanceColour = AdjustColorForDistance(shadeColour, distance, farthestCell.Value);
                            Brush brush = new SolidBrush(distanceColour);


                            graphics.FillRectangle(brush, new Rectangle(xPos, yPos, currentMazeSettings.CellWidth, currentMazeSettings.CellHeight));
                        }

                        if (!cell.HasLinkedNeighbourInDirection(Direction.North))
                        {
                            graphics.FillRectangle(Brushes.Red, northRect);
                        }
                        if (!cell.HasLinkedNeighbourInDirection(Direction.East))
                        {
                            graphics.FillRectangle(Brushes.Red, eastRect);
                        }
                        if (!cell.HasLinkedNeighbourInDirection(Direction.South))
                        {
                            graphics.FillRectangle(Brushes.Red, southRect);
                        }
                        if (!cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            graphics.FillRectangle(Brushes.Red, westRect);
                        }

                        if (chkShowCoordinates.Checked)
                        {
                            drawCoordinates(graphics, cell, xPos, yPos);
                        }

                        //if (distances.CellsAndTheirDistanceFromRoot.TryGetValue(cell, out int value2))
                        //{
                        //    var distance = value2;
                        //    graphics.DrawString($"{distance}", DefaultFont, Brushes.Black, new PointF(xPos, yPos));
                        //}
                    }
                }
            }
        }
    }

    private void panel_Draw_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        graphics.Clear(Color.White);
        drawGrid(graphics);
    }

    private void button_Export_Click(object sender, EventArgs e)
    {
        Bitmap bitmap = new(grid.Columns * currentMazeSettings.CellWidth, grid.Rows * currentMazeSettings.CellHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Graphics graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.White);

        drawGrid(graphics);

        bitmap.Save(@"C:\test.png", ImageFormat.Png);
    }

    private void drawCoordinates(Graphics graphics, GridCell cell, int xPos, int yPos)
    {
        graphics.DrawString($"{cell.Xposition}:{cell.Yposition}", DefaultFont, Brushes.Black, new PointF(xPos, yPos));
    }

    private void chkShowCoordinates_CheckedChanged(object sender, EventArgs e)
    {
        panel_Draw.Invalidate();
    }

    private Color AdjustColorForDistance(Color color, int distanceFromRoot, int furthestDistanceFromRoot)
    {
        float red = (float)color.R;
        float green = (float)color.G;
        float blue = (float)color.B;

        float correctionFactor = ((float)(furthestDistanceFromRoot - distanceFromRoot)) / furthestDistanceFromRoot;

        if (correctionFactor < 0)
        {
            correctionFactor = 1 + correctionFactor;
            red *= correctionFactor;
            green *= correctionFactor;
            blue *= correctionFactor;
        }
        else
        {
            red = (255 - red) * correctionFactor + red;
            green = (255 - green) * correctionFactor + green;
            blue = (255 - blue) * correctionFactor + blue;
        }

        var adjustedColour = Color.FromArgb(color.A, (int)red, (int)green, (int)blue);


        return adjustedColour;
    }
}
