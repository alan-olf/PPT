﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPT.App.Core.GuardClause
{
    public interface IGuardClause
    {
    }

    public class Guard : IGuardClause
    {
        public static IGuardClause Against { get; } = new Guard();
        private Guard() { }
    }

}
