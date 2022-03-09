using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVC_AdopterUnDev.Models
{
    public class PrototypeLogin
    {
        /* Legend: 
         * ScaffoldColumn(false) -> cela n'apparait pas dans le formulaire en html, mais il existe 
         * et il est très important pout parler à la DB :pour interroger la base de données, BD, nous recherchons 
         * souvent les données (client, factures, ..) par identifiant, car c'est unique
         *
         *DisplayName("bla bla bla :) ") -> ton label en html
         *
         *Required -> il ne faut pas l'oublier pour les champs importants
         */
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DisplayName("Login : ")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string login { get; set; }

        [Required]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        public string psw { get; set; }

        /* avant le bouton 'submit' (créé automatiquement par Razor) 
         * il est préférable d'ajouter ce bouton. */

        [Required]
        [DisplayName("Veuillez confirmer la connexion :")]
        [DisplayFormat]
        public bool Validate { get; set; }


    }
}
