﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SumUpApp
{
    public class UserPlayer: Player
    {
        public UserPlayer(ref CaroBoard board) : base(ref board)
        {
        }

        public override void Move()
        {
            base.Move();
        }
    }
}