using CRUD.ENUMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu Alan Zorunlu")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunlu")]
        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

    }
}
