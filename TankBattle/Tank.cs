using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankBattle
{
    class Tank
    {
        public Texture2D PlayerTexture;
        public Vector2 Position;
        public float Rotation;
        public bool Active;
        public int Hp;
        public int Width
        {
            get { return PlayerTexture.Width; }
        }
        public int Height
        {
            get { return PlayerTexture.Height; }
        }

        public void Initialize(Texture2D playerTexture, Vector2 position, float rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.PlayerTexture = playerTexture;
            Hp = 3;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, Rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }


    }
}
