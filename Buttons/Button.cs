using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace March_Game_Jam.Buttons {
    class Button {
        public string text;
        public List<Button> children = new List<Button>();
        public Button parent;
        public bool selected = false;

        public Button(string Text, Button Parent) {
            text = Text;
            parent = Parent;
        }

        public void addChild(Button b) {
            children.Add(b);
        }


    }
}
