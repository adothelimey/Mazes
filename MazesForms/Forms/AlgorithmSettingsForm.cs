using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGrid;
using TheGrid.Mazes.Algorithms;

namespace MazesForms.Forms;

public partial class AlgorithmSettingsForm : Form
{
    Array directionValues = Enum.GetValues(typeof(Direction));
    static int directionIndex = 0;
    static int directionBias = 50;

    public int GetDirectionBias()
    {
        return directionBias;
    }

    public Tuple<Direction, Direction> GetDirections()
    {
        Direction directionA;
        Direction directionB;
        Tuple<Direction, Direction> directionAB;


        switch (((string)comboBox1.SelectedItem).ToUpper())
        {
            case "NORTHEAST":
            default:
                {
                    directionA = Direction.North;
                    directionB = Direction.East;
                    break;
                }
            case "NORTHWEST":
                {
                    directionA = Direction.North;
                    directionB = Direction.West;
                    break;
                }
            case "SOUTHWEST":
                {
                    directionA = Direction.South;
                    directionB = Direction.West;
                    break;
                }
            case "SOUTHEAST":
                {
                    directionA = Direction.South;
                    directionB = Direction.East;
                    break;
                }
        }

        directionAB = new Tuple<Direction, Direction>(directionA, directionB);

        return directionAB;
    }


    public AlgorithmSettingsForm(MazeSettings mazeSettings)
    {
        InitializeComponent();
    }

    private string[] GetDirectionEnumNames()
    {
        string[] enumDirectionNames = new string[directionValues.Length];
        for (int i = 0; i < enumDirectionNames.Length; i++)
        {
            enumDirectionNames[i] = Enum.GetName(typeof(Direction), directionValues.GetValue(i));
        }

        return enumDirectionNames;
    }

    private void AlgorithmSettingsForm_Load(object sender, EventArgs e)
    {
        comboBox1.SelectedIndex = directionIndex;
        trkBias.Value = directionBias;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        directionIndex = comboBox1.SelectedIndex;
    }

    private void trkBias_Scroll(object sender, EventArgs e)
    {
        directionBias = trkBias.Value;
    }
}
