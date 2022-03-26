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
    public class Item_Menu_Exit_Button : Entity
    {
        public Item_Menu item_Menu;
        public Item_Menu_Exit_Button(Item_Menu an_item_Menu) : base(){
            item_Menu = an_item_Menu;
            x= item_Menu.x;
            y= item_Menu.y;
            hitBox.X=x;
            hitBox.Y=y;
            imageBox.X = 0;
            imageBox.Y = 0;
            imageBox.Width = 7;
            imageBox.Height = 7;
            width = imageBox.Width;
            height = imageBox.Height;
            hitBox.Width = width;
            hitBox.Height = height;
            layer=3;
        }
        public override void Draw(SpriteBatch sb)
        {
            if (item_Menu.state=="OPEN"){
                //sb.Draw(Game1.item_menu_exit_button_img,hitBox,imageBox,Color.White);
            }
        }

        public override void Update()
        {
            //if (Game1.MouseHoveredEntities.Contains(this) && Game1.mouseClicked && Game1.the_item_menu.state=="OPEN"){
                //Game1.the_item_menu.Close();
            //}
        }
    }
}