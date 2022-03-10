namespace March_Game_Jam.Helpers
{
    public class animationFrame
    {
        public string filename;
        public int framex, framey, framew, frameh;
        public bool isRotated;
        public bool isTrimmed;
        public int spriteSourceSizex, spriteSourceSizey, spriteSourceSizew, spriteSourceSizeh;
        public int sourceSizew, sourceSizeh;
        public int duration;

        public animationFrame(string a_filename, int a_framex, int a_framey, int a_framew, int a_frameh,
            bool a_isRotated, bool a_isTrimmed, int a_spriteSourceSizex, int a_spriteSourceSizey, int a_spriteSourceSizew, int a_spriteSourceSizeh,
            int a_sourceSizew, int a_sourceSizeh, int a_duration)
        {
            filename = a_filename;
            framex = a_framex;
            framey = a_framey;
            framew = a_framew;
            frameh = a_frameh;
            isRotated = a_isRotated;
            isTrimmed = a_isTrimmed;
            spriteSourceSizex = a_spriteSourceSizex;
            spriteSourceSizey = a_spriteSourceSizey;
            spriteSourceSizew = a_spriteSourceSizew;
            spriteSourceSizeh = a_spriteSourceSizeh;
            sourceSizew = a_sourceSizew;
            sourceSizeh = a_sourceSizeh;
            duration = a_duration;
            
        }

    }
    
}