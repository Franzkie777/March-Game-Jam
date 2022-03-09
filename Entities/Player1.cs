using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March_Game_Jam.Entities
{
    class Player1 : Entity
    {
        public Player1(int startX, int startY)
        {
            x = startX;
            y = startY;
            width = 20;
            height = 20;
            updateHitBox();
        }

        //The new keyword lets this method override the default Entity draw method
        //This lets us specify how this particular entity will be drawn, as opposed
        //to other entities
        public new void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.pallete, Game1.blue, hitBox, Color.White);
        }


    }
}
