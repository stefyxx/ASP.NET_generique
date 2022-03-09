using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_MVC_visuel.Models
{
    public class PrototypeEdit
    {
        /* chaque prototype prend également le nom de son IAction, dans son Controller
         * cela te permettra de comprendre immédiatement ce que tu vois 
        * ou ce que tu récupéres de ta vue*/
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public string lastName { get; set; }

        [ScaffoldColumn(false)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [EmailAddress(ErrorMessage = "Insertion pas valide! )")]
        [DisplayName("Mail : ")]
        public string email { get; set; }

        [DisplayName("Login : ")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string login { get; set; }

        [Required]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        public string psw { get; set; }

        //si un client ne souhaite plus en être un, je, dans le Contrôleur, le rend inactif
        [ScaffoldColumn(false)]
        public bool Validate { get; set; }

        [Required]
        [DisplayName("Êtes-vous sûr de vouloir modifier cet prototype ?")]
        public bool etreClient { get; set; }
    }
}
