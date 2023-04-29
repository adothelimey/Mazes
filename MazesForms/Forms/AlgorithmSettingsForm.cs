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

        //BindControls();
    }

    private void BindControls()
    {
        ////direction Enum
        //cboBTDirectionA.DataSource = GetDirectionEnumNames(); ;
        //cboBTDirectionB.DataSource = GetDirectionEnumNames();

        //cboBTDirectionA.SelectedItem = Enum.GetName(typeof(Direction), directionValues.GetValue(0));
        //cboBTDirectionB.SelectedItem = Enum.GetName(typeof(Direction), directionValues.GetValue(1));


        //cboBTDirectionA_SelectedIndexChanged(cboBTDirectionA, EventArgs.Empty);
        //cboBTDirectionB_SelectedIndexChanged(cboBTDirectionB, EventArgs.Empty);
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

    private void cboBTDirectionA_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////remove direction A from direction B selection

        //int selectedIndexA = cboBTDirectionA.SelectedIndex;
        //cbo


        //var selectedItemA = (string)cboBTDirectionA.SelectedItem;
        //var selectedItemAValue = (Direction)Enum.Parse(typeof(Direction), selectedItemA);



        //var newDataSource = GetDirectionEnumNames().Where(x => x != selectedItemA).ToArray();

        //var bItem = cboBTDirectionB.SelectedItem;
        //cboBTDirectionB.DataSource = newDataSource;
        //cboBTDirectionB.SelectedItem = bItem;
    }

    private void cboBTDirectionB_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////remove direction B from direction A selection
        //var selectedItemB = (string)cboBTDirectionB.SelectedItem;
        //var selectedItemBValue = (Direction)Enum.Parse(typeof(Direction), selectedItemB);

        //var newDataSource = GetDirectionEnumNames().Where(x => x != selectedItemB).ToArray();
        //var aItem = cboBTDirectionA.SelectedItem;
        //cboBTDirectionA.DataSource = newDataSource;
        //cboBTDirectionA.SelectedItem = aItem;
    }
}
