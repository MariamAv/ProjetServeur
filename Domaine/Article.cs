﻿using System;
using System.Collections.Generic;

namespace ProjetServeur.Domaine
{
    public partial class Article : Model
    {
        public Article()
        {
            Contient = new HashSet<Contient>();
            Ecrire = new HashSet<Ecrire>();
            InverseArticleNavigation = new HashSet<Article>();
        }

        //public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public int? ArticleId { get; set; }

        public virtual Article ArticleNavigation { get; set; }
        public virtual ICollection<Contient> Contient { get; set; }
        public virtual ICollection<Ecrire> Ecrire { get; set; }
        public virtual ICollection<Article> InverseArticleNavigation { get; set; }
    }
}
