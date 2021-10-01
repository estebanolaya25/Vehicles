﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.API.Data.Entities
{
    public class VehiclePhoto
    {
        public int Id { get; set; }

        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

   
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
           ? $"https://localhost:44312/images/NoImage.jpg"
            : $"https://vehiclejuanolaya.blob.core.windows.net/vehicles/{ImageId}";
    }
}
