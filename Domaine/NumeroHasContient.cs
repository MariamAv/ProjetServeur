﻿using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    public partial class NumeroHasContient
    {
        public int NumeroId { get; set; }
        public int ContientArticleId { get; set; }

        public virtual Numero Numero { get; set; }
    }
}
