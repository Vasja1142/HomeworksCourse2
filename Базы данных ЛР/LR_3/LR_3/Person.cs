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
        public int Id { get; set; }            // SERIAL PRIMARY KEY

        [Column("name")]                       // Имя колонки в базе данных
        public string name { get; set; }        // VARCHAR(35) NOT NULL

        [Column("phone")]                      // Имя колонки в базе данных
        public string phone { get; set; }       // VARCHAR(11) NOT NULL

        [Column("experience")]                 // Имя колонки в базе данных
        public int experience { get; set; }     // INT NOT NULL

        [Column("salary")]                     // Имя колонки в базе данных
        public int salary { get; set; }         // INT NOT NULL

        [Column("adress")]                     // Имя колонки в базе данных
        public string adress { get; set; }      // VARCHAR(100) NOT NULL
    }
}