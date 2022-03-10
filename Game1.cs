using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using March_Game_Jam.Buttons;
using System.IO;
using System.Collections.Generic;

namespace March_Game_Jam
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static List<Entities.Entity> Entities = new List<Entities.Entity>();

        public static Texture2D pallete;
        public static Texture2D textbox_img;

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
        private Entities.Player1 testPlayer = new Entities.Player1(350, 150);

        private Entities.TextBox testTextBox = new Entities.TextBox(450,250,"Content/TextBox.json");

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

            pallete = Texture2D.FromFile(GraphicsDevice, "Content/pallete.png");
            textbox_img = Texture2D.FromFile(GraphicsDevice, "Content/TextBox.png");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(Entities.Entity e in Entities)
                e.Update();

            base.Update(gameTime);
        }

        protected override async void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            foreach(Entities.Entity e in Entities)
                e.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public static void AddEntity(Entities.Entity e) {
            Entities.Add(e);
        }

        public static void RemoveEntity(Entities.Entity e) {
            Entities.Remove(e);
        }
    }
}
