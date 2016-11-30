using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Homework1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<MyTexture> textures;
        List<VisibleGameEntity> entities;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            Global.Content = this.Content;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            textures = new List<MyTexture>();
            entities = new List<VisibleGameEntity>();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            

            // load background
            entities.Add(new MyTexture("forest", 0, 0, 800, 600));

            GenerateAngle("Angel", 15, 50, 400);

            GenerateRockman(50, 500);

            //GenerateNPC("Rockman", 11, 50, 100);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Global.Camera.Update(gameTime);
            Global.MouseHelper.Update(gameTime);

            if (Global.MouseHelper.IsBeginToClickLeftButton())
            {
                float ScreenX = Global.MouseHelper.GetCurrentX();
                float ScreenY = Global.MouseHelper.GetCurrentY();
                Vector2 screenPos = new Vector2(ScreenX, ScreenY);
                Vector2 worldPos = Vector2.Transform(screenPos, Global.Camera.InvWVP);

                int selectedIdx = -1;
                for (int i = entities.Count - 1; i >= 0; i--)
                    if (entities[i].IsSelected(worldPos.X, worldPos.Y)) //Global.MouseHelper.GetCurrentX(), Global.MouseHelper.GetCurrentY()))
                    {
                        selectedIdx = i;
                        break;
                    }

                if (selectedIdx != -1)
                {
                    for (int i = 0; i < entities.Count; i++)
                        if (selectedIdx == i)
                            entities[i].State = 1;
                        else
                            entities[i].State = 0;
                }
            }

            //for (int i = 0; i < sprites.Count; i++)
            //    sprites[i].Update(gameTime);

            for (int i = 0; i < entities.Count; i++)
                entities[i].Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Global.Camera.WVP);

            // drawing textures
            //for (int i = 0; i < textures.Count; i ++)
            //{
            //    textures[i].Draw(gameTime, spriteBatch);
            //}

            // drawing sprites
            //for (int i = 0; i < sprites.Count; i++)
            //{
            //    sprites[i].Draw(gameTime, spriteBatch);
            //}

            // drawing visible entities
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void GenerateAngle(string strResourcePrefix, int nTextures, float left, float top)
        {
            List<Texture2D> textures = LoadTextures(strResourcePrefix, nTextures);
            My2DSprite newSprite = new My2DSprite(textures, left, top, 0, 0);
            //sprites.Add(newSprite);
            entities.Add(newSprite);
        }

        private void GenerateRockman(int left, int top)
        {
            Rockman rockman = new Rockman(left, top);
            entities.Add(rockman);
        }

        private List<Texture2D> LoadTextures(string strResourcePrefix, int nTextures)
        {
            List<Texture2D> textures = new List<Texture2D>();
            for (int i = 1; i <= nTextures; i++)
            {
                textures.Add(Content.Load<Texture2D>(strResourcePrefix + i.ToString("00")));
            }
            return textures;
        }
    }
}
