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
    public class Problem : Entity
    {
        public dynamic problem_dict;
        public int problem_index;
        public string problem_name;
        public string problem_display_name;
        public string problem_description;
        public List<Solution> problem_solution_sets;
        
        public List<ShipEffect> problem_ship_effects;
        public Problem(string problem_name) : base()
        {
            //load problem from problem_list.json
            problem_dict = Game1.problem_list_json["problems"][problem_name];
            problem_index = problem_dict["index"];
            this.problem_name = problem_dict["problem_name"];
            problem_display_name = problem_dict["problem_display_name"];
            problem_description = problem_dict["description"];
            problem_solution_sets = problem_dict["solution_sets"];
            problem_ship_effects = problem_dict["ship_effects"];
        }
    }
}