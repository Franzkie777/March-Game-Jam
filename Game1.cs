using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using March_Game_Jam.Buttons;
using System.IO;

namespace March_Game_Jam
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Texture2D pallete;
        public static Rectangle red = new Rectangle(0, 0, 1, 1),
            blue = new Rectangle(1, 0, 1, 1),
            green= new Rectangle(2, 0, 1, 1),
            orange = new Rectangle(3, 0, 1, 1),
            pink = new Rectangle(4, 0, 1, 1),
            yellow = new Rectangle(5, 0, 1, 1),
            cyan = new Rectangle(6, 0, 1, 1),
            magenta = new Rectangle(7, 0, 1, 1),
            black = new Rectangle(8, 0, 1, 1),
            white = new Rectangle(9, 0, 1, 1);
        private Button inventory = new Button("Inventory", null);
        private Button engine = new Button("Engine", null);
        private Button Scanner = new Button("Scanner", null);
        private Entities.Player1 testPlayer = new Entities.Player1(400, 60);
        
        private Entities.TextBox testTextBox = new Entities.TextBox(400,80,"Content/TextBox.json");
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pallete = Texture2D.FromFile(GraphicsDevice, "Content/TextBox.png");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            testPlayer.Draw(_spriteBatch);
            testTextBox.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
