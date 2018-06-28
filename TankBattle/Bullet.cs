using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankBattle
{
    class Bullet
    {
        public Texture2D BulletTexture;
        public Vector2 Position;
        public float Rotation;
        private Viewport viewport;
        private float Speed = 7f;
        public bool Active = false;
        public int Width
        {
            get { return BulletTexture.Width; }
        }
        public int Height
        {
            get { return BulletTexture.Height; }
        }

        public void Initialize(Texture2D bulletTexture, Viewport viewport, Vector2 position, float rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.BulletTexture = bulletTexture;
            this.viewport = viewport;
            Active = true;
        }

        public void Update()
        {
            Position += GetFwdVector() * Speed;
            
            Vector2 origin = new Vector2(viewport.TitleSafeArea.X, viewport.TitleSafeArea.Y);
            Vector2 max = new Vector2(viewport.TitleSafeArea.Width, viewport.TitleSafeArea.Height);

            if (Position.X < origin.X || Position.X > max.X || Position.Y < origin.Y || Position.Y > max.Y)
            {
                Active = false;
            }
        }

        private Vector2 GetFwdVector()
        {
            double r = (double)Rotation;
            return new Vector2(-(float)Math.Sin(r), (float)Math.Cos(r));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BulletTexture, Position, null, Color.White, Rotation, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }

    }
}
