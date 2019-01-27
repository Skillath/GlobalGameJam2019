using GGJ2019.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IEnemyMovement
    {
        Vector Position { get; set; }

        bool CanMove { set; }

        float Speed { get; }
    }
}
