using Microsoft.Xna.Framework.Graphics;
using March_Game_Jam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March_Game_Jam.GameStates
{
    public class FightScene : GameState
    {
        public static Child child;
        public static Dad dad;
        public static ActionButton[] actionList = new ActionButton[4];
        public FightScene() : base()
        {
            dad = new Dad(100, 150);
            child = new Child(300, 150);
            void Test() {
                Console.WriteLine("test");
            };
            for(int i = 0; i < 4; i++) {
                actionList[i] = new Entities.ActionButton(100, i * 40 + 300, 100, 30, "Action Number " + i.ToString(), Test);
            }
        }

        public override void Update()
        {
            
        }

        public override void Draw(SpriteBatch sb)
        {
            
        }


    }
}
