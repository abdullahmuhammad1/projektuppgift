using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project3
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D ship;
        Vector2 shipPosition = new Vector2(400, 400);
        float shipSpeed = 3;
        KeyboardState tangentbord = Keyboard.GetState();

        Texture2D background;
        Vector2 backgroundposition = new Vector2(0, 0);

        Texture2D alienbild;
        List<Vector2> alienpositioner = new List<Vector2>();
        float alienspeed = 1;

        Texture2D BulletBild;
        Rectangle BulletRectangle;

        KeyboardState tangentBord = Keyboard.GetState();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    alienpositioner.Add(new Vector2(75 + 75 * x, 75 + 60 * y));
                }
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship = Content.Load<Texture2D>("space invaders ship");

            background = Content.Load<Texture2D>("space invaders background");

            alienbild = Content.Load<Texture2D>("space invaders alien");

            BulletBild = Content.Load<Texture2D>("bullet");

            BulletRectangle = new Rectangle(400, 400, BulletBild.Width / 2, BulletBild.Height / 2);

        }

        protected override void Update(GameTime gameTime)
        {
            tangentbord = Keyboard.GetState();

            if (tangentbord.IsKeyDown(Keys.Left) || tangentbord.IsKeyDown(Keys.A))
            {
                shipPosition.X -= shipSpeed;
            }
            if (tangentbord.IsKeyDown(Keys.Right) || tangentbord.IsKeyDown(Keys.D))
            {
                shipPosition.X += shipSpeed;
            }
                       
            tangentBord = Keyboard.GetState();

            Vector2 temp;
            for (int i = 0; i < alienpositioner.Count; i++)
            {
                temp = alienpositioner[i];

                if (temp.X >= 0 || temp.X <= 800)
                {
                   
                    temp.X -= alienspeed;
                }
                if (temp.X <= 0 || temp.X >= 750)
                {
                    alienspeed *= -1;
                }
                alienpositioner[i] = temp; 
            }




            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundposition, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.Draw(ship, shipPosition, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            foreach (Vector2 alienposition in alienpositioner)
            {
                spriteBatch.Draw(alienbild, alienposition, Color.White);
            }
            spriteBatch.End();


            spriteBatch.Begin();
            spriteBatch.Draw(BulletBild, shipPosition, Color.White);
            spriteBatch.End(); 
            base.Draw(gameTime);
        }
    }
}
