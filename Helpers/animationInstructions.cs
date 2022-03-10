using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;


namespace March_Game_Jam.Helpers
{
    public class animationInstructions
    {
        public string animationInstructions_filepath;
        public dynamic animationInstructions_json;
        public List<animationFrame> animationFrame_list = new List<animationFrame>();
        public animationInstructions(string animationInstructions_filepath)
        {
            //read in animation instructions from animation"s json file.
            //Exported as part of spritesheet from Aseprite.
            animationInstructions_json = JsonConvert.DeserializeObject(File.ReadAllText(animationInstructions_filepath));
            //add each frame dictionary from json file to a list.
            foreach (dynamic frame in animationInstructions_json["frames"])
            {
                string filename = frame["filename"];
                int framex = frame["frame"]["x"];
                int framey = frame["frame"]["y"];
                int framew = frame["frame"]["w"];
                int frameh = frame["frame"]["h"];
                bool rotated = frame["rotated"];
                bool trimmed = frame["trimmed"];
                int spriteSourceSizex = frame["spriteSourceSize"]["x"];
                int spriteSourceSizey = frame["spriteSourceSize"]["y"];
                int spriteSourceSizew = frame["spriteSourceSize"]["w"];
                int spriteSourceSizeh = frame["spriteSourceSize"]["h"];
                int sourceSizew = frame["sourceSize"]["w"];
                int sourceSizeh = frame["sourceSize"]["h"];
                int duration = frame["duration"];
                animationFrame my_animationFrame = new animationFrame(filename,framex,framey,framew,frameh,rotated,trimmed,spriteSourceSizex,spriteSourceSizey,spriteSourceSizew,spriteSourceSizeh,sourceSizew,sourceSizeh,duration);
                animationFrame_list.Add(my_animationFrame);
            }
        }




    }


}