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
    class TextBox : Entity
    {
        public string animationInstructions_filepath;
        public animationInstructions animationInstruction;
        public animationFrame currentFrame; 
        public TextBox(int startX, int startY, string textbox_animation_instructions_filepath)
        {
            x = startX;
            y = startY;
            animationFrame_idx = 0;
            animationInstructions_filepath = textbox_animation_instructions_filepath;
            animationInstruction = new animationInstructions(animationInstructions_filepath);
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            // imageBox.X = currentFrame.framex;
            // imageBox.Y = currentFrame.framey;
            // imageBox.Width = currentFrame.framew;
            // imageBox.Height = currentFrame.frameh;

            imageBox.X = 0;
            imageBox.Y = 496;
            imageBox.Width = 900;
            imageBox.Height = 900;
            updateHitBox();
        }
        public new void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.pallete, hitBox, imageBox, Color.Red);
        }

        public new void Animation(int animationRate)
        {
            foreach(animationFrame frame in animationInstruction.animationFrame_list)
            {
                
            }
        }

        public new void Close_Animation()
        {
            
        }
    }
}