﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMatch.Shared.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        public int age { get; set; }

        [Required(ErrorMessage = "La descripción personal es obligatoria.")]
        public string PersonalDescription { get; set; }

        [Required(ErrorMessage = "Los intereses son obligatorios.")]
        public string Interests { get; set; }

        [Required(ErrorMessage = "La orientación sexual es obligatoria.")]
        public string SexualOrientation { get; set; }

        public string CivilState { get; set; }

        public string Occupation { get; set; }

        public string ProfilePictures { get; set; }

        public string AdditionalPhotos { get; set; }

        public string LinkNetworks { get; set; }

        public float Height { get; set; }

        public int Weight { get; set; }

        public string Nacionality { get; set; }


    }
}
