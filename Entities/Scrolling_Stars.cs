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
    class Scrolling_Stars : Entity
    {
        public string animationInstructions_filepath;
        public animationInstructions animationInstruction;
        public animationFrame currentFrame;
        public int last_frame_idx;
        public int current_speed;
        public Scrolling_Stars(string scrolling_stars_animation_instruction_filepath) : base()
        {
            x=0;
            y=0;
            animationFrame_idx = 0;
            animationInstructions_filepath = scrolling_stars_animation_instruction_filepath;
            animationInstruction = new animationInstructions(animationInstructions_filepath);
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            imageBox.X = currentFrame.framex;
            imageBox.Y = currentFrame.framey;
            imageBox.Width = currentFrame.framew;
            imageBox.Height = currentFrame.frameh;
            width = currentFrame.framew;
            height = currentFrame.frameh;
            hitBox.Width = width;
            hitBox.Height = height;
            current_speed = 1;
            hitBox.Width = 432;
            hitBox.Height = 500;
            last_frame_idx = animationInstruction.animationFrame_list.Count();
            layer=1;
        }

        public void updateCurrentAnimationFrame(int i)
        {
            animationFrame_idx +=i;
            if (animationFrame_idx>=last_frame_idx){
                animationFrame_idx=animationFrame_idx-last_frame_idx;
            }
            currentFrame = animationInstruction.animationFrame_list[animationFrame_idx];
            imageBox.X = currentFrame.framex;
            imageBox.Y = currentFrame.framey;
            imageBox.Width = currentFrame.framew;
            imageBox.Height = currentFrame.frameh;
            width = currentFrame.framew;
            height = currentFrame.frameh;
            
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.scrolling_stars_img,hitBox,imageBox,Color.White);
        }

        public override void Update()
        {
            updateCurrentAnimationFrame(1*current_speed);
        }
    }
}