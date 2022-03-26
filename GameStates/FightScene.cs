using Microsoft.Xna.Framework.Graphics;
using March_Game_Jam.Entities;

namespace March_Game_Jam.GameStates
{
    public class FightScene : GameState
    {
        public static Child child;
        public static Dad dad;
        public static ActionButton[] actionList = new ActionButton[4];

        public FightScene() : base()
        {
            //Instantiate and draw Dad and Child Objects.
            dad = new Dad(100, 150);
            child = new Child(300, 150);
            //



            for(int i = 0; i < 4; i++) {
                actionList[i] = new Entities.ActionButton(100, i * 40 + 300, 100, 30, "Action Number " + i.ToString());
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
