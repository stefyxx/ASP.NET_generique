using Asp_MVC_visuel.Models;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AdopterUnDev.Handlers
{
    public static class Mapper
    {
        //LES METHODES SONT TOUS STATIC sinon je ne peux pas les utiliser dans d'autres parties du projet

        /* dans la vue j'ai un prototypeQuelqueChose (un objet):
         *chaque prototypeBLL doit être transformé en chaque prototypeQuelqueChose
         *donc: pour chaque prototypeQuelqueChose créer une méthode 'transformation'->
         *qui récupère un prototypeBLL et le transforme en prototypeQuelqueChose */

        /*l'inverse : un prototypeQuelqueChose transformé en prototypeBLL serait fait directement dans le POST de nos IActions dans le Controller */

        /* ToList-> un prototypeBLL est transformé en prototypeList */
        public static PrototypeList ToList(this BLL.Models.Prototype prototypeBLL)
        {
            if (prototypeBLL is null) return null;
            return new PrototypeList
            {
                id = prototypeBLL.id,
                lastName = prototypeBLL.lastName,
                firstName = prototypeBLL.firstName,
                //Je n'ai créé que ceux-ci,
                //mais si tu en as d'autres,AVANT DE CRéER LA VIEW ajoutes-les dans prototypeList

            };
        }

        /* ToDetails-> un prototypeBLL est transformé en prototypeDetails */
        public static PrototypeDetails ToDetails(this BLL.Models.Prototype prototypeBLL)
        {
            if (prototypeBLL is null) return null;
            return new PrototypeDetails
            {
                id = prototypeBLL.id,
                lastName = prototypeBLL.lastName,
                firstName = prototypeBLL.firstName,
                profession = prototypeBLL.profession,

                //Je n'ai créé que ceux-ci,
                //mais si tu en as d'autres,AVANT DE CRéER LA VIEW ajoutes-les dans prototypeDetails

            };
        }

        /* ToCreate-> un prototypeBLL est transformé en prototypeCreate */
        public static PrototypeCreate ToCreate(this BLL.Models.Prototype prototypeBLL)
        {
            if (prototypeBLL is null) return null;
            return new PrototypeCreate
            {
                id = prototypeBLL.id,
                lastName = prototypeBLL.lastName,
                firstName = prototypeBLL.firstName,
                profession = prototypeBLL.profession,
                dateBirthDate = prototypeBLL.dateBirthDate,
                email = prototypeBLL.email,
                login = prototypeBLL.login,
                psw = prototypeBLL.psw,

            };
        }
        public static PrototypeEdit ToEdit(this BLL.Models.Prototype prototypeBLL)
        {
            if (prototypeBLL is null) return null;
            return new PrototypeEdit
            {
                id = prototypeBLL.id,
                lastName = prototypeBLL.lastName,
                firstName = prototypeBLL.firstName,
                email = prototypeBLL.email,
                login = prototypeBLL.login,
                psw = prototypeBLL.psw,
                ///A CONTINUER

            };
        }
        /* ToDelete-> un prototypeBLL est transformé en prototypeDelete */
        public static PrototypeDelete ToDelete(this BLL.Models.Prototype prototypeBLL)
        {
            if (prototypeBLL is null) return null;
            return new PrototypeDelete
            {
                id = prototypeBLL.id,
                lastName = prototypeBLL.lastName,
                firstName = prototypeBLL.firstName,
                email = prototypeBLL.email,
                Validate = false
                /* 'Valider' me permet de NE PAS SUPPRIMER le prototype de la base de données, 
                 * mais seulement de le rendre inactif
                 * (imaginez toutes les factures émises par le client,
                 * j'ai besoin qu'elles restent stockées même si je n'ai plus le client) */
            };
        }
        
    }
}
