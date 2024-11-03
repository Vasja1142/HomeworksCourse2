using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{
    internal class DataTables
    {
        internal static List<Person> AddDataPersons()
        {
            var persons = new List<Person>
                {
                    new Person { name = "Гордеев Василий Андреевич", phone = "1234567890", experience = 3, salary = 60000, adress = "Кунгур", DepartmentId = 1 },
                    new Person { name = "Потапов Емельян Святославович", phone = "9876543210", experience = 5, salary = 80000, adress = "Екатеринбург", DepartmentId = 2 },
                    new Person { name = "Гордеев Эрик Онисимович", phone = "9876543210", experience = 4, salary = 30000, adress = "Пермь", DepartmentId = 3 },
                    new Person { name = "Ефремов Максим Игоревич", phone = "9876543210", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 4 },
                    new Person { name = "Кулаков Виктор Миронович", phone = "9876543211", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 1 },
                    new Person { name = "Дементьев Виссарион Святославович", phone = "9876543214", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 3 },
                    new Person { name = "Егоров Виталий Пётрович", phone = "9876543217", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 2 },
                    new Person { name = "Якушев Карл Георгьевич", phone = "9876543216", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 2 },
                    new Person { name = "Андреев Иван Яковлевич", phone = "9876543217", experience = 1, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 2 },
                    new Person { name = "Исаков Адольф Давидович", phone = "9876543110", experience = 2, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 4 },
                    new Person { name = "Пестов Вилен Христофорович", phone = "9876545310", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 2 },
                    new Person { name = "Кудрявцев Петр Артёмович", phone = "9876543210", experience = 3, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 2 },
                    new Person { name = "Орехов Остап Натанович", phone = "9876552410", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 2 },
                    new Person { name = "Дорофеев Гордей Михайлович", phone = "9876543210", experience = 5, salary = 80000, adress = "ул. Лермонтова, д. 2", DepartmentId = 3 },

                };
            return persons;
        }

        internal static List<Department> AddDataDepartment()
        {

            var departments = new List<Department>
            {
                    new Department { Name = "IT", Persons = new List<Person>() },
                    new Department { Name = "Marketing", Persons = new List<Person>()},
                    new Department { Name = "Sales", Persons = new List<Person>() },
                    new Department { Name = "HR", Persons = new List<Person>() }

            };
            return departments;
        }

    }
}
