using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace March_Game_Jam.Entities
{
    public class Child : Entity
    {
        public static Texture2D kidPic;
        public static Rectangle kidPicBox;

        public static Dictionary<dynamic,dynamic> char_content_dict;

        public int age;
        public List<string> flags;
        public Texture2D eye_img;
        public Texture2D hair_img;
        public Texture2D pants_img;
        public Texture2D shirt_img;
        public Texture2D shoes_img;
        public Texture2D skin_img;
        
        public Child(int startX, int startY) : base(5)
        {
            eye_img = char_content_dict["Teen\\Eye\\Brown.png"];
            hair_img = char_content_dict["Teen\\Hair\\3.png"];
            pants_img = char_content_dict["Teen\\Pants\\Blue.png"];
            shirt_img = char_content_dict["Teen\\Shirt\\Red.png"];
            shoes_img = char_content_dict["Teen\\Shoes\\Grey.png"];
            skin_img = char_content_dict["Teen\\Skin\\2.png"];

            
            
            
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
            sb.Draw(eye_img, hitBox, kidPicBox, Color.White);
            sb.Draw(hair_img, hitBox, kidPicBox, Color.White);
            sb.Draw(pants_img, hitBox, kidPicBox, Color.White);
            sb.Draw(shirt_img, hitBox, kidPicBox, Color.White);
            sb.Draw(shoes_img, hitBox, kidPicBox, Color.White);
            sb.Draw(skin_img, hitBox, kidPicBox, Color.White);

        }
    }
}
