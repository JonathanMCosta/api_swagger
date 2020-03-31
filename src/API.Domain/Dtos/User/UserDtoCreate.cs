﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required (ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength (60, ErrorMessage = "Nome deve ter no máximo {1} caractreres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório para o login")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no maximo {1} caracteres")]
        public string Email { get; set; }
    }
}
