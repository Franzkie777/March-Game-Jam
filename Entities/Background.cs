using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using March_Game_Jam.Helpers;

namespace March_Game_Jam.Entities
{
    class Background : Entity
    {
        public Background() : base()
        {
            x=0;
            y=0;
            imageBox.X = 0;
            imageBox.Y = 0;
            imageBox.Width = 432;
            imageBox.Height = 500;
            width = 432;
            height = 500;
            hitBox.Width = 432;
            hitBox.Height = 500;
            layer=0;
        }

        public override void Draw(SpriteBatch sb)
        {
            //sb.Draw(Game1.background_img,hitBox,imageBox,Color.White);
        }
    }
}