using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_MVC_visuel.Models
{
    public class PrototypeCreate
    {
        /*Ici tu écriras:
         * chaque propriété sera un nom de colonne dans votre base de données */

        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required]
        [DisplayName("Nom: ")]
        public string lastName { get; set; }

        [Required]
        [DisplayName("Prénom : ")]
        public string firstName { get; set; }

        [Required]
        [DisplayName("Profession : ")]
        public string profession { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de naissance : ")]
        public DateTime dateBirthDate { get; set; }

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



    }
}
