using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using March_Game_Jam.Entities;
using System;

namespace March_Game_Jam.GameStates
{
    public class FightScene : GameState
    {
        public static Child child;
        public static Dad dad;
        public static ActionButton[] actionList = new ActionButton[4];
        public static Texture2D background,
        bottomMenu;
        public static Rectangle backgroundRect,
        bottomMenuRect;
        public enum state {
            playerTurnInput,
            playerTurnResult,
            childTurnResult
        }
        public state fightState = state.childTurnResult;
        public FightScene() : base()
        {
            //Instantiate and draw Dad and Child Objects.
            dad = new Dad(100, 150);
            child = new Child(300, 150);
            void Test() {
                Console.WriteLine("test");
            };
            actionList[0] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 1", Test);
            actionList[1] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 2", Test);
            actionList[2] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 3", Test);
            actionList[3] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 4", Test);
        }

        public override void Update()
        {
            
        }

        public override async void Draw(SpriteBatch sb)
        {
            backgroundRect = new Rectangle(0, 0, Game1.screen_width, background.Bounds.Height * Game1.screen_width / background.Bounds.Width);
            sb.Draw(background, backgroundRect, background.Bounds, Color.White);
            bottomMenuRect = new Rectangle(0, Game1.screen_height - (bottomMenu.Bounds.Height * Game1.screen_width / bottomMenu.Bounds.Width), Game1.screen_width, bottomMenu.Bounds.Height * Game1.screen_width / bottomMenu.Bounds.Width);
            sb.Draw(bottomMenu, bottomMenuRect, bottomMenu.Bounds, Color.White);
            double xScaling = (double)bottomMenuRect.Width / bottomMenu.Bounds.Width;
            double yScaling = (double)bottomMenuRect.Height / bottomMenu.Bounds.Height;
            Console.WriteLine(xScaling);
            actionList[0].hitBox.X = (int)(106 * xScaling);
            actionList[0].hitBox.Y = Game1.screen_height - (int)(308 * yScaling);
            actionList[0].hitBox.Width = (int)(402 * xScaling);
            actionList[0].hitBox.Height = (int)(129 * yScaling);
            actionList[1].hitBox.X = actionList[0].hitBox.X;
            actionList[1].hitBox.Y = Game1.screen_height - (int)(153 * yScaling);
            actionList[2].hitBox.X = (int)(536 * xScaling);
            actionList[2].hitBox.Y = actionList[0].hitBox.Y;
            actionList[3].hitBox.X = actionList[2].hitBox.X;
            actionList[3].hitBox.Y = actionList[1].hitBox.Y;
            for(int i = 1; i < 4; i++) {
                actionList[i].hitBox.Width = actionList[0].hitBox.Width;
                actionList[i].hitBox.Height = actionList[0].hitBox.Height;
            }
        }


    }
}
