﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern.Models
{
        public class User
        {
            [Key]
            public int UserId { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }

