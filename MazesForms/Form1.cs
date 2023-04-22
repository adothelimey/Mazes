using System.Drawing;
using System.Drawing.Imaging;

namespace MazesForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void drawPanel_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;

        graphics.DrawRectangle(Pens.Green, new Rectangle(0, 0, 64, 64));
        graphics.FillRectangle(Brushes.HotPink, new Rectangle(1, 1, 63, 63));

    }

    private void button_exportToImage_Click(object sender, EventArgs e)
    {
        Bitmap bitmap = new Bitmap(Convert.ToInt32(1024), Convert.ToInt32(1024), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Graphics graphics = Graphics.FromImage(bitmap);

        // Add drawing commands here
        graphics.DrawRectangle(Pens.Green, new Rectangle(0, 0, 64, 64));
        graphics.FillRectangle(Brushes.HotPink, new Rectangle(1, 1, 63, 63));

        bitmap.Save(@"C:\test.png", ImageFormat.Png);
    }
}