using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace March_Game_Jam.Entities
{
    public class Child : Entity
    {
        public static Texture2D kidPic;
        public static Rectangle kidPicBox;
        
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
            sb.Draw(kidPic, hitBox, kidPicBox, Color.White);
        }
    }
}
