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
        public Player1(int startX, int startY) : base()
        {
            x = startX;
            y = startY;
            width = 200;
            height = 200;
            updateHitBox();
            layer=1;
        }

        //The new keyword lets this method override the default Entity draw method
        //This lets us specify how this particular entity will be drawn, as opposed
        //to other entities
        public override void Draw(SpriteBatch sb)
        {
            //sb.Draw(Game1.pallete, hitBox, Game1.blue, Color.White);
        }
    }
}
