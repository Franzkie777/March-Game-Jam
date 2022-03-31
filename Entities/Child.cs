using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace March_Game_Jam.Entities
{
    public class Child : Entity
    {
        public static Texture2D kidPic;
        public static Rectangle kidPicBox;
        public int age;
         public List<string> flags;

        
        public Child(int startX, int startY) : base(5)
        {
            x = startX;
            y = startY;
            width = 200;
            height = 200;
            updateHitBox();
        }

        public override void Draw(SpriteBatch sb)
        {
            x = Game1.screen_width * 2 / 3;
            y = Game1.screen_height / 3;
            updateHitBox();
            sb.Draw(kidPic, hitBox, kidPicBox, Color.White);
        }
    }
}
