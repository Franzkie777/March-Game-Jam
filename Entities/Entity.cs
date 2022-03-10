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
    public class Entity
    {
        public int x, y, width, height;
        public Rectangle hitBox = new Rectangle(), imageBox = new Rectangle();
        public Texture2D image;

        public int animationFrame_idx;

        public Entity()
        {
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
