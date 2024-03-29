﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BulletHell
{
    class SimpleEnem : GameObject
    {
        public static Texture2D Texture2D { get; set; }
        public static Point TextureSize;
        private int cicle = 1;
        private float HP = 6;
        private int fireTimer = Room.Rand.Next(1, 20);
        private int roundCicle = Room.Rand.Next(-1, 1);

        public bool NearWall
        {
            get
            {
                return (LeftWall || RightWall || UpWall || DownWall);
            }
        }
        public bool LeftWall
        {
            get
            {
                return (this.GetPos().X < Level.roomPos.X);
            }
        }

        public bool UpWall
        {
            get
            {
                return (this.GetPos().Y < Level.roomPos.Y - TextureSize.Y);
            }
        }
        public bool RightWall
        {
            get
            {
                return (this.GetPos().X > Objects.windowWidth - TextureSize.X - Level.roomPos.X);
            }
        }
        public bool DownWall
        {
            get
            {
                return (this.GetPos().Y > Objects.windowHeight - TextureSize.Y - Level.roomPos.Y);
            }
        }                   

        public void ChengeHP(float shift)
        {
            HP += shift;
        }
        public float GetHP()
        {
            return HP;
        }

        public static void CountTextureSizeAndCicles(Point size)
        {
            TextureSize = size;
        }

        public Rectangle GetCollusion()
        {
            return new Rectangle((int)this.GetPos().X,
            (int)this.GetPos().Y, TextureSize.X, TextureSize.Y);
        }

        public void Update()
        {

            if (fireTimer == 0)
            {
                Objects.CreateProj(GetPos(), new Point((int)Hero1.GetPos().X, (int)Hero1.GetPos().Y),
                    Objects.ProjTexture2D, 2.5f, Level.rooms[Level.GetHeroInRoomValue()].enProjectiles, true, 0, 0);
                fireTimer++;
            }
            else
                if (fireTimer == 80)
                fireTimer = 0;
            else
                fireTimer += Room.Rand.Next(1, 2);
            UpdatePos(this.GetPos() + this.CalcDir()/3);
            if (UpWall)
                UpdatePos(this.GetPos() + new Vector2(0, 2));
            if (DownWall)
                UpdatePos(this.GetPos() - new Vector2(0, 2));
            if (LeftWall)
                UpdatePos(this.GetPos() + new Vector2(2, 0));
            if (RightWall)
                UpdatePos(this.GetPos() - new Vector2(2, 0));
        }

        private Vector2 CalcDir()
        {
            if (this.GetPos().Y > Objects.windowHeight - Texture2D.Height - Level.roomPos.Y)
                roundCicle = 1;
            if (this.GetPos().Y < Level.roomPos.Y - Hero1.Texture2D.Height)
                roundCicle = -1;
            var angle = Math.Atan2(Hero1.GetPos().Y - this.GetPos().Y, Hero1.GetPos().X - this.GetPos().X);
            var dir = new Vector2((float)(Math.Cos(angle) * 5), (float)(Math.Sin(angle) * 5));
            var dir2 = new Vector2((float)(Math.Cos(1.57 + angle) * 5), (float)(Math.Sin(1.57 + angle) * 5));
            var length = Math.Sqrt((Hero1.GetPos().X - this.GetPos().X) * (Hero1.GetPos().X - this.GetPos().X) + 
                (Hero1.GetPos().Y - this.GetPos().Y) * (Hero1.GetPos().Y - this.GetPos().Y));
            var result = Vector2.Zero;
            if (length > 400 || LeftWall )
            {
                cicle = 1;

            }
            else
            if (length < 150)
            {
                cicle = -1;

            }
            result += dir * cicle + dir2 * roundCicle;
            return result;
        }



        public void Draw()
        {
            if (Hero1.GetPos().X < GetPos().X + 30)
            {
                spriteBatch.Draw(Texture2D, GetPos(), null, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.5f);
            }
            else
                spriteBatch.Draw(Texture2D, GetPos(), null, Color.White, 0, Vector2.Zero, 2, SpriteEffects.FlipHorizontally, 0.5f);

        }
    }
}
