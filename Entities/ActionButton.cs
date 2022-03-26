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
    public class ActionButton : Entity
    {
        string actionName = "";
        public ActionButton(int xCenter, int yCenter, int xWidth, int yWidth, string name) : base(10)
        {
            actionName = name;
            x = xCenter - xWidth / 2;
            y = yCenter - yWidth / 2;
            hitBox.X = x;
            hitBox.Y = y;
            width = xWidth;
            height = yWidth;
            hitBox.Width = width;
            hitBox.Height = height;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.pallete,hitBox,Game1.blue,Color.White);
            //TODO: Write ability name
        }

        public override void Update()
        {
            if (Game1.MouseHoveredEntities.Contains(this) && Game1.mouseClicked){
                //Do ability
            }
        }
    }
}