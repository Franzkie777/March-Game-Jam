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
    public class Item_Menu : Entity
    {
        public string state;
        public Item_Menu() : base()
        {
            x= 10;
            y= 10;
            hitBox.X=x;
            hitBox.Y=y;
            imageBox.X = 0;
            imageBox.Y = 0;
            imageBox.Width = 146;
            imageBox.Height = 141;
            width = imageBox.Width;
            height = imageBox.Height;
            hitBox.Width = width;
            hitBox.Height = height;
            layer=2;
            state = "CLOSED";
        }

        public override void Draw(SpriteBatch sb)
        {
            if (state=="OPEN")
            {
                sb.Draw(Game1.item_menu_img,hitBox,imageBox,Color.White);
            }
            else{}
        }
        
        public void Open()
        {
            state = "OPEN";
        }

        public void Close()
        {
            state = "CLOSED";
        }
    }
}