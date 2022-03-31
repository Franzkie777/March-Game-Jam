using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace March_Game_Jam.Entities
{
    public class Dad : Entity
    {
        public static Texture2D dadPic;
        public static Rectangle dadPicBox;
        public static int lawfulness = 0,
        goodness = 0,
        wisdom = 0,
        intelligence = 0,
        charisma = 0,
        money = 100;
        public List<string> flags;
        public static Dictionary<dynamic,dynamic> char_content_dict;
        public static Texture2D dad_eye_img;
        public static Texture2D dad_hair_img;
        public static Texture2D dad_pants_img;
        public static Texture2D dad_shirt_img;
        public static Texture2D dad_shoes_img;
        public static Texture2D dad_skin_img;

        public Dad(int startX, int startY, string dad_eye, ) : base(5)
        {
            dad_eye_img = char_content_dict["Dad\\Eye\\Green.png"];
            dad_hair_img = char_content_dict["Dad\\Hair\\5.png"];
            dad_pants_img = char_content_dict["Dad\\Pants\\Green.png"];
            dad_shirt_img = char_content_dict["Dad\\Shirt\\Yellow.png"];
            dad_shoes_img = char_content_dict["Dad\\Shoes\\Black.png"];
            dad_skin_img = char_content_dict["Dad\\Skin\\12.png"];
            
            
            x = startX;
            y = startY;
            width = 200;
            height = 200;
            updateHitBox();
        }

        public override void Draw(SpriteBatch sb)
        {
            x = Game1.screen_width / 3;
            y = Game1.screen_height / 3;
            updateHitBox();
            sb.Draw(dad_eye_img, hitBox, dadPicBox, Color.White);
            sb.Draw(dad_hair_img, hitBox, dadPicBox, Color.White);
            sb.Draw(dad_pants_img, hitBox, dadPicBox, Color.White);
            sb.Draw(dad_shirt_img, hitBox, dadPicBox, Color.White);
            sb.Draw(dad_shoes_img, hitBox, dadPicBox, Color.White);
            sb.Draw(dad_skin_img, hitBox, dadPicBox, Color.White);
        }
    }
}
