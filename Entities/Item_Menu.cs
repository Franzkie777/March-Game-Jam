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
        public int size_scalar;
        public Item_Menu() : base(2)
        {
            size_scalar = 300; 
            x= 10;
            y= 10;
            hitBox.X=x;
            hitBox.Y=y;
            imageBox.X = 0;
            imageBox.Y = 0;
            imageBox.Width = 138;
            imageBox.Height = 121;
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
                //sb.Draw(Game1.item_menu_img,hitBox,imageBox,Color.White);
            }
            else{}
        }
        
        public void Open()
        {
            state = "OPEN";
            Item test_item = new Item("test_item");
            Game1.storage.add_to_storage(test_item);
        }

        public void Close()
        {
            state = "CLOSED";
        }
    }
}