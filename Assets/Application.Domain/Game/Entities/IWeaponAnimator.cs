﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IWeaponAnimator
    {
        void PlaySpawnAnimation();

        void PlayEffectAnimation();

        void PlayDeathAnimation();
    }
}
