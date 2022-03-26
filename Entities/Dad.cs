using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace March_Game_Jam.Entities
{
    public class Dad : Entity
    {
        public static Texture2D dadPic;
        public static Rectangle dadPicBox;
        public static int lawfulness = 0, goodness = 0, wisdom = 0, intelligence = 0, charisma = 0;
        public Dad(int startX, int startY) : base(5)
        {
            x = startX;
            y = startY;
            width = 200;
            height = 200;
            updateHitBox();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(dadPic, hitBox, dadPicBox, Color.White);
        }
    }
}
