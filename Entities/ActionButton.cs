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
        System.Action action;
        bool clicked = false;
        public Texture2D buttonUp, buttonDown;
        public Rectangle buttonUpRect, buttonDownRect;
        public ActionButton(int xCenter, int yCenter, int xWidth, int yWidth, string name, System.Action act) : base(10)
        {
            action = act;
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
            if(!clicked) {
                if(buttonUp != null && buttonUpRect != null)
                    sb.Draw(buttonUp, hitBox, buttonUpRect, Color.White);
                sb.DrawString(Game1.font, actionName, new Vector2(hitBox.X + hitBox.Width / 2 - nameWidth / 2, hitBox.Y + hitBox.Height / 2 - nameHeight / 2), Color.White);
            }
            else {
                if(buttonDown != null && buttonDownRect != null)
                    sb.Draw(buttonDown, hitBox, buttonDownRect, Color.White);
                sb.DrawString(Game1.font, actionName, new Vector2(hitBox.X + hitBox.Width / 2 - nameWidth / 2, hitBox.Y + hitBox.Height / 2 - nameHeight / 2), Color.Black);
            }
            
        }

        public override void Update()
        {
            if (Game1.MouseHoveredEntities.Contains(this) && Game1.mouseClicked){
                clicked = true;
                action();
            }
            if(!Game1.MouseHoveredEntities.Contains(this) || !Game1.mouseDown) {
                clicked = false;
            }
        }

    }
}