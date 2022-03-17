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

        public string state;
        public TextBox(int startX, int startY, string textbox_animation_instructions_filepath) : base()
        {
            x = startX;
            y = startY;
            animationFrame_idx = 0;
            animationInstructions_filepath = textbox_animation_instructions_filepath;
            animationInstruction = new animationInstructions(animationInstructions_filepath);
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            imageBox.X = currentFrame.framex;
            imageBox.Y = currentFrame.framey;
            imageBox.Width = currentFrame.framew;
            imageBox.Height = currentFrame.frameh;
            width = currentFrame.framew;
            height = currentFrame.frameh;
            state = "CLOSED";
            hitBox.Width = width;
            hitBox.Height = height;

        }

        public void updateCurrentAnimationFrame(int i)
        {
            animationFrame_idx +=i;
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            imageBox.X = currentFrame.framex;
            imageBox.Y = currentFrame.framey;
            imageBox.Width = currentFrame.framew;
            imageBox.Height = currentFrame.frameh;
            width = currentFrame.framew;
            height = currentFrame.frameh;
            hitBox.Width = width;
            hitBox.Height = height;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.textbox_img, hitBox, imageBox, Color.White *0.5f);
        }

        public override void Update()
        {
            if (state =="OPENING")
            {
                Opening();
            }
            else if (state =="CLOSING")
            {
                Closing();
            }
            else if (state =="OPEN")
            {
                Closing();
            }
            else{
                Opening();
            }
            //if clauses that call their own state function
        }

        public void Opening(int i=1){
            if (animationInstruction.animationFrame_list.Count()-1 != animationFrame_idx)
            {
                updateCurrentAnimationFrame(i);
                state = "OPENING";
            }
            else
            {
                state = "OPEN";
            }

        }
        public void Closing(int i=-1){
            if (animationFrame_idx>0)
            {
                updateCurrentAnimationFrame(i);
                state = "CLOSING";
            }
            else
            {
                state = "CLOSED";
            }
        }
        public void Open(){
            animationFrame_idx = animationInstruction.animationFrame_list.Count()-1;
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            imageBox.X = currentFrame.framex;
            imageBox.Y = currentFrame.framey;
            imageBox.Width = currentFrame.framew;
            imageBox.Height = currentFrame.frameh;
            width = currentFrame.framew;
            height = currentFrame.frameh;
            hitBox.Width = width;
            hitBox.Height = height;
        }
        public void Closed(){
            animationFrame_idx = 0;
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            imageBox.X = currentFrame.framex;
            imageBox.Y = currentFrame.framey;
            imageBox.Width = currentFrame.framew;
            imageBox.Height = currentFrame.frameh;
            width = currentFrame.framew;
            height = currentFrame.frameh;
            hitBox.Width = width;
            hitBox.Height = height;
        }
    }
}