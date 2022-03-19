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
    public class Solution : Entity
    {
        public List<string> solution_attributes;
        public string solution_description; 
        public Solution(Dictionary<string,dynamic> solution_set) : base()
        {
            solution_attributes = solution_set["solution_attributes"];
            solution_description = solution_set["solution_description"];
        }
    }
}