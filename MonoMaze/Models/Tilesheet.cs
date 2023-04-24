using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoMaze.Models
{
    public class Tilesheet
    {
        public Texture2D Texture { get; set; }

        public TilesheetAtlas Atlas { get; set; }
    }
}
