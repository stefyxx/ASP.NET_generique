﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_MVC_visuel.Models
{
    public class PrototypeDelete
    {
        /* chaque prototype prend également le nom de son IAction, dans son Controller
         * cela te permettra de comprendre immédiatement ce que tu vois 
         * ou ce que tu récupéres de ta vue*/

        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required]
        [DisplayName("Nom: ")]
        public string lastName { get; set; }

        [Required]
        [DisplayName("Prénom : ")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [EmailAddress(ErrorMessage = "Insertion pas valide! )")]
        [DisplayName("Mail : ")]
        public string email { get; set; }

        [Required]
        [DisplayName("Voulez-vous vraiment supprimer le prototype ?")]
        public bool Validate { get; set; }
    }
}
