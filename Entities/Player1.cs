﻿using Microsoft.Xna.Framework;
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
        public static int pCount = 0;
        public Rectangle color = Game1.blue;

        public Player1(int startX, int startY) : base()
        {
            x = startX;
            y = startY;
            width = 200;
            height = 200;
            updateHitBox();
<<<<<<< HEAD

            if(pCount == 1){
                color = Game1.red;
            }

            if(pCount == 2) {
                color = Game1.green;
            }
            pCount++;
=======
            layer=1;
>>>>>>> bfc324036e188c54cbc5679efc89130404a56e19
        }

        //The new keyword lets this method override the default Entity draw method
        //This lets us specify how this particular entity will be drawn, as opposed
        //to other entities
        public override void Draw(SpriteBatch sb)
        {
<<<<<<< HEAD
            sb.Draw(Game1.pallete, hitBox, color, Color.White);
=======
            //sb.Draw(Game1.pallete, hitBox, Game1.blue, Color.White);
>>>>>>> bfc324036e188c54cbc5679efc89130404a56e19
        }
    }
}
