﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulletHell
{
    internal static class MoveSet
    {

        static public void MoveLeft()
        {
            var heroPos = Hero1.GetPos();
            heroPos.X -= 230 * (30 / 1000f);
            Hero1.UpdatePos(heroPos);
        }

        static public void MoveRight()
        {
            var heroPos = Hero1.GetPos();
            heroPos.X += 230 * (30 / 1000f);
            Hero1.UpdatePos(heroPos);
        }

        static public void MoveUp()
        {
            var heroPos = Hero1.GetPos();
            heroPos.Y -= 230 * (30 / 1000f);
            Hero1.UpdatePos(heroPos);
        }

        static public void MoveDown()
        {
            var heroPos = Hero1.GetPos();
            heroPos.Y += 230 * (30 / 1000f);
            Hero1.UpdatePos(heroPos);
        }


    }
}
