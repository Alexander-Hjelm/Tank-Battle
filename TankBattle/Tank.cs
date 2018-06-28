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
        private float Speed = 5f;
        private float RotSpeed = 0.06f;
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

        public void Move(float offset)
        {
            Position += GetFwdVector() * offset * Speed;
        }

        public void Turn(float offset)
        {
            Rotation += offset * RotSpeed;
        }

        private Vector2 GetFwdVector()
        {
            double r = (double)Rotation;
            return new Vector2(-(float)Math.Sin(r), (float)Math.Cos(r));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, Rotation, new Vector2(Width/2, Height/2), 1f, SpriteEffects.None, 0f);
        }


    }
}
