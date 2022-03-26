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
        int nameWidth, nameHeight;
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
            Vector2 measurement = Game1.font.MeasureString(actionName);
            nameWidth = (int)measurement.X;
            nameHeight = (int)measurement.Y;
        }

        public override async void Draw(SpriteBatch sb)
        {
            
            sb.Draw(Game1.pallete,hitBox,Game1.blue,Color.White);
            sb.DrawString(Game1.font, actionName, new Vector2(x + width / 2 - nameWidth / 2, y + height / 2 - nameHeight / 2), Color.White);
        }

        public override void Update()
        {
            if (Game1.MouseHoveredEntities.Contains(this) && Game1.mouseClicked){
                //Do ability
            }
        }

    }
}