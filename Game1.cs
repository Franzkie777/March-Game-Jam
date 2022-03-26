using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using March_Game_Jam.Buttons;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using March_Game_Jam.GameStates;
using March_Game_Jam.Entities;

namespace March_Game_Jam
{
    public class Game1 : Game
    {

        //Mouse Stuff
        private static bool mouseWasUp = false;
        public static bool mouseClicked = false;
        public static bool mouseDown = false;
        public static GameState currentGameState;

        //Graphics
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int screen_width;
        public static int screen_height;

        public void UpdateScreenSize()
        {
            screen_width = GraphicsDevice.Viewport.Width;
            screen_height = GraphicsDevice.Viewport.Height;
        }

        //Entities
        public static List<Entities.Entity> Entities = new List<Entities.Entity>();
        public static List<Entities.Entity> add_Entities = new List<Entities.Entity>();
        public static List<Entities.Entity> remove_Entities = new List<Entities.Entity>();
        public static List<Entities.Entity> MouseHoveredEntities = new List<Entities.Entity>();
        public static SpriteFont font;
        public static Texture2D pallete;
        public static Texture2D textbox_img;
        //private static Player1 testPlayer = new Player1(100, 100);

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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        public Texture2D AddContent(string filename)
        {
            Debug.WriteLine("test");
            Texture2D content;
            content = Texture2D.FromFile(GraphicsDevice,filename);
            return content;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //graphics
            //font = Content.Load<SpriteFont>("Terminal");
            pallete = Texture2D.FromFile(GraphicsDevice, "Content/pallete.png");
            Dad.dadPic = Texture2D.FromFile(GraphicsDevice, "Content/Dad1.png");
            Dad.dadPicBox = new Rectangle(0, 0, Dad.dadPic.Width, Dad.dadPic.Height);
            Child.kidPic = Texture2D.FromFile(GraphicsDevice, "Content/Baby2.png");
            Child.kidPicBox = new Rectangle(0, 0, Child.kidPic.Width, Child.kidPic.Height);
            
            // TODO: use this.Content to load your game content here
            currentGameState = new FightScene();
            
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateScreenSize();
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
            
            foreach(Entities.Entity e in remove_Entities)
                RemoveQueued(e);

            foreach(Entities.Entity e in add_Entities)
                AddQueued(e);

            remove_Entities.Clear();
            add_Entities.Clear();

            base.Update(gameTime);
        }

        protected override async void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointClamp);

            currentGameState.Draw(_spriteBatch);

            foreach(Entities.Entity e in Entities)
                e.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public static void AddQueued(Entities.Entity e) {
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

        public static void RemoveQueued(Entities.Entity e) {
            Entities.Remove(e);
        }

        public static void AddEntity(Entities.Entity e) {
            add_Entities.Add(e);
        }

        public static void RemoveEntity(Entities.Entity e) {
            remove_Entities.Add(e);
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
