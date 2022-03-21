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
    public class ShipEffect : Entity
    {
        public dynamic ship_effect_dict;
        public int ship_effect_index;
        public string ship_effect_name;
        public string ship_effect_display_name;
        public string ship_effect_description;
        public Dictionary<string,dynamic> ship_effect_base_alterations;
        public List<Alteration> ship_effect_function_alterations;
        public ShipEffect(string effect_name) : base()
        {
            //load ship effect from ship_effects_list.json.
            ship_effect_dict = Game1.ship_effects_list_json["effects"][effect_name];
            ship_effect_index = ship_effect_dict["index"];
            ship_effect_name = ship_effect_dict["effect_name"];
            ship_effect_display_name = ship_effect_dict["effect_display_name"];
            ship_effect_description = ship_effect_dict["description"];
            ship_effect_base_alterations = ship_effect_dict["base_alteration"];
            ship_effect_function_alterations = ship_effect_dict["function_alterations"];
        }
    }
}