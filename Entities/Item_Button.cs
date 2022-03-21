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
    public class Item_Button :Entity
    {
        public Item_Button() : base(1)
        {
            x= 10;
            y= 10;
            hitBox.X=x;
            hitBox.Y=y;
            imageBox.X = 0;
            imageBox.Y = 0;
            imageBox.Width = 159;
            imageBox.Height = 46;
            width = imageBox.Width;
            height = imageBox.Height;
            hitBox.Width = width;
            hitBox.Height = height;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.item_menu_button_img,hitBox,imageBox,Color.White);
        }

        public override void Update()
        {
            if (Game1.MouseHoveredEntities.Contains(this) && Game1.mouseClicked){
                Game1.the_item_menu.Open();
            }
        }
    }
}