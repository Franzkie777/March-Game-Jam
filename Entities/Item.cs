using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using March_Game_Jam.Helpers;

namespace March_Game_Jam.Entities
{
    public class Item : Entity
    {
        public dynamic item_dict;
        public string item_idx_str;
        public string item_index;
        public string item_name;
        public string item_graphic_source;
        public string item_display_name;
        public string item_description;
        public List<string> item_attributes;
        public Dictionary<string,dynamic> item_starting_stats;

        public static Texture2D item_graphic;
        public Item(string item_name) : base()
        {
            //load item info from item_list.json
            item_dict = Game1.item_list_json["items"][item_name];
            item_index = item_dict["index"];
            this.item_name = item_dict["item_name"];
            item_graphic_source = item_dict["item_graphic_source"];
            item_display_name = item_dict["item_display_name"];
            item_description = item_dict["description"];
            item_attributes = item_dict["item_attributes"];
            item_starting_stats = item_dict["item_starting_stats"];            

            
        }
        
        public override void Draw(SpriteBatch sb)
        {
            
        }

    }
}