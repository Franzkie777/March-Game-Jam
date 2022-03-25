using Microsoft.Xna.Framework.Graphics;

namespace March_Game_Jam.GameStates
{
    public class FightScene : GameState
    {
        public static int playerHealth = 100, enemyHealth = 100;
        public static Entities.ActionButton[] actionList = new Entities.ActionButton[4];

        public FightScene() : base()
        {
            for(int i = 0; i < 4; i++) {
                actionList[i] = new Entities.ActionButton(100, i * 40, 100, 30, "Action Number " + i.ToString());
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
