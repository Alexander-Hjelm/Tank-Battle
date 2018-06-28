using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankBattle
{
    class Tank
    {
        public Texture2D PlayerTexture;
        public Texture2D BulletTexture;
        public Vector2 Position;
        private Viewport viewport;
        public float Rotation;
        private Bullet bullet;
        private float MaxSpeed = 5f;
        private float MaxRotSpeed = 0.06f;
        private float Speed = 0f;
        private float RotSpeed = 0f;
        private float SpeedIncr = 0.04f;
        private float RotSpeedIncr = 0.002f;
        private float SpeedDecr = 0.02f;
        private float RotSpeedDecr = 0.0015f;
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

        public void Initialize(Texture2D playerTexture, Texture2D bulletTexture, Viewport viewport, Vector2 position, float rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.PlayerTexture = playerTexture;
            this.BulletTexture = bulletTexture;
            this.viewport = viewport;
            Hp = 3;
            bullet = new Bullet();
        }

        public void Update()
        {
            Position += GetFwdVector() * Speed;
            Rotation += RotSpeed;

            Speed -= Math.Sign(Speed) * SpeedDecr;
            RotSpeed -= Math.Sign(RotSpeed) * RotSpeedDecr;

            if (bullet.Active)
            {
                bullet.Update();
            }
        }

        public void Move(float offset)
        {
            if (offset > 0 && Speed < MaxSpeed)
            {
                Speed += SpeedIncr;
            }
            else if (offset < 0 && Speed > -MaxSpeed)
            {
                Speed -= SpeedIncr;
            }
        }

        public void Turn(float offset)
        {
            if (offset < 0 && RotSpeed > -MaxRotSpeed)
            {
                RotSpeed -= RotSpeedIncr;
            }
            else if (offset > 0 && RotSpeed < MaxRotSpeed)
            {
                RotSpeed += RotSpeedIncr;
            }
        }

        public void Shoot()
        {
            if (!bullet.Active)
            {
                bullet.Initialize(BulletTexture, viewport, Position, Rotation);
            }
        }

        private Vector2 GetFwdVector()
        {
            double r = (double)Rotation;
            return new Vector2(-(float)Math.Sin(r), (float)Math.Cos(r));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, Rotation, new Vector2(Width/2, Height/2), 1f, SpriteEffects.None, 0f);

            if (bullet.Active)
            {
                bullet.Draw(spriteBatch);
            }
        }

    }
}
