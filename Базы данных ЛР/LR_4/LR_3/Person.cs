using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{
    internal class Person
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("phone")]
        public string phone { get; set; }
        [Column("experience")]
        public int experience { get; set; }
        [Column("salary")]
        public int salary { get; set; }
        [Column("adress")]
        public string adress { get; set; }
        [Column("departmentid")]

        public int? DepartmentId { get; set; } // Внешний ключ для Department
        public Department Department { get; set; } // Навигационное свойство для Department
    }
}