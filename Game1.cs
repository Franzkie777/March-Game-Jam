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
        private static bool mouseWasUp = false;
        public static bool mouseClicked = false;
        public static bool mouseDown = false;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static List<Entities.Entity> Entities = new List<Entities.Entity>();
        public static List<Entities.Entity> MouseHoveredEntities = new List<Entities.Entity>();

        public static Texture2D pallete;
        public static Texture2D textbox_img;
        public static Texture2D background_img;
        public static Texture2D scrolling_stars_img;
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
       
        private Entities.Background background = new Entities.Background();

        private Entities.TextBox testTextBox = new Entities.TextBox(450,250,"Content/TextBox.json");
        private Entities.Scrolling_Stars scrolling_stars = new Entities.Scrolling_Stars("Content/Scrolling Stars.json");
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
            
            background_img = Texture2D.FromFile(GraphicsDevice, "Content/Starry Background.png");

            pallete = Texture2D.FromFile(GraphicsDevice, "Content/pallete.png");
            textbox_img = Texture2D.FromFile(GraphicsDevice, "Content/TextBox.png");
            scrolling_stars_img = Texture2D.FromFile(GraphicsDevice,"Content/Scrolling Stars.png");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            MouseHoveredEntities.Clear();
            mouseClicked = MouseClickCheck();
            mouseDown = MouseDownCheck();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(Entities.Entity e in Entities) {
                if(MouseOver(e.hitBox)) {
                    MouseHoveredEntities.Add(e);
                }
            }

            foreach(Entities.Entity e in Entities)
                e.Update();
                
            base.Update(gameTime);
        }

        protected override async void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointClamp);

            foreach(Entities.Entity e in Entities)
                e.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public static async void AddEntity(Entities.Entity e) {
            bool added = false;
            for(int i = 0; i < Entities.Count; i++) {
                if(Entities[i].layer >= e.layer) {
                    Entities.Insert(i, e);
                    added = true;
                    i = Entities.Count;
                }
            }

            if(!added) {
                Entities.Add(e);
            }
        }

        public static void RemoveEntity(Entities.Entity e) {
            Entities.Remove(e);
        }

        public static bool MouseOver(Rectangle rect) {
            bool mouseOver = false;
            MouseState mState = Mouse.GetState();
            if(mState.X >= rect.X && mState.X <= rect.X + rect.Width) {
                if(mState.Y >= rect.Y && mState.Y <= rect.Y + rect.Height) {
                    mouseOver = true;
                }
            }
            return mouseOver;
        }

        //This function returns true as long as the mouse button is held down
        public static bool MouseDownCheck() {
            return Mouse.GetState().LeftButton.Equals(ButtonState.Pressed);
        }

        //This function returns true only if the mouse button was down and was previously seen as up.
        public static bool MouseClickCheck() {
            bool mouseNowDown = Mouse.GetState().LeftButton.Equals(ButtonState.Pressed);
            bool clicked = (mouseWasUp && mouseNowDown);
            mouseWasUp = !mouseNowDown;
            return clicked;
        }

    }
}
