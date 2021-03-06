using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace March_Game_Jam.Entities
{
    public class Entity
    {
        public int x, y, width, height;
        public Rectangle hitBox = new Rectangle(), imageBox = new Rectangle();
        public Texture2D image;

        public int animationFrame_idx, layer = 0;

        public Entity()
        {
            Game1.AddEntity(this);
        }

        public Entity(int Layer)
        {
            layer = Layer;
            Game1.AddEntity(this);
        }

        public void Destroy()
        {
            Game1.RemoveEntity(this);
        }

        public void updateHitBox()
        {
            hitBox.Width = width;
            hitBox.Height = height;
            hitBox.X = x - width / 2;
            hitBox.Y = y - height / 2;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }



    }
}
