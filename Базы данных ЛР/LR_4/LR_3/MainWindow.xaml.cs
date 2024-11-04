using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LR_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateDepartmentsTableWithData_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    // Проверяем, существует ли таблица
                    if (context.Departments.Any())
                    {
                        MessageBox.Show("Таблица Departments уже существует.");
                        return;
                    }


                    context.Database.EnsureCreated(); // <- Создать таблицу ДО добавления данных


                    var departments = DataTables.AddDataDepartment();

                    context.Departments.AddRange(departments);
                    context.SaveChanges();
                    MessageBox.Show("Таблица Departments создана и данные добавлены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }



        private void CreateTableGordeevWithData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    // 1. Сначала создаем таблицу
                    context.Database.EnsureCreated();


                    // 1. Проверка существования таблицы Persons (table_gordeev)
                    if (context.Persons.Any())
                    {
                        MessageBox.Show("Таблица table_gordeev уже существует.");
                        return;
                    }

                    // 2. Проверка существования таблицы Departments
                    if (!context.Departments.Any())
                    {
                        MessageBox.Show("Таблица Departments не существует. Создайте её перед добавлением данных в table_gordeev.");
                        return;
                    }

                    // 3. EnsureCreated() в отдельном контексте для избежания проблем с кэшем
                    context.Database.EnsureCreated();

                    // 4. Получение данных для добавления
                    var persons = DataTables.AddDataPersons();

                    // 5. Проверка DepartmentId перед добавлением Person
                    foreach (var person in persons)
                    {
                        if (!context.Departments.Any(d => d.Id == person.DepartmentId))
                        {
                            MessageBox.Show($"Отдел с ID {person.DepartmentId} не существует. Исправьте данные перед добавлением.");
                            return;
                        }
                    }


                    // 6. Добавление данных и сохранение изменений с обработкой исключений
                    try
                    {
                        context.Persons.AddRange(persons);
                        context.SaveChanges();
                        MessageBox.Show("Таблица table_gordeev создана и данные добавлены.");
                    }
                    catch (Exception saveEx)
                    {
                        MessageBox.Show($"Ошибка при сохранении данных: {saveEx.Message}\n\n{saveEx.InnerException?.Message}"); // Вывод внутренней ошибки, если есть
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n\n{ex.InnerException?.Message}"); // Вывод внутренней ошибки
            }
        }
        private void DeleteDepartmentsTable_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    // Проверяем, существует ли таблица
                    if (!context.Departments.Any())
                    {
                        MessageBox.Show("Таблица Departments не существует.");
                        return;
                    }

                    context.Database.ExecuteSqlRaw("DROP TABLE departments"); // Удаляем таблицу departments
                    MessageBox.Show("Таблица Departments удалена.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void DeletePersonsTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ApplicationContext()) // Первый контекст для удаления таблицы
                {
                    if (!context.Persons.Any())
                    {
                        MessageBox.Show("Таблица table_gordeev не существует.");
                        return;
                    }

                    context.Database.ExecuteSqlRaw("DROP TABLE table_gordeev");
                    MessageBox.Show("Таблица table_gordeev удалена.");
                } // context.Dispose() вызывается автоматически здесь

                using (var context = new ApplicationContext()) // Новый контекст для создания таблицы
                {
                    context.Database.EnsureCreated();
                    MessageBox.Show("Таблица table_gordeev создана."); // Добавлено сообщение об успешном создании
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void QueryTable_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var query1 = context.Persons
                    .Select(u => new { u.name, u.phone, u.salary,  u.adress, u.experience})
                    .ToList();

                // Отображаем результат в DataGrid
                QueryDataGrid.ItemsSource = query1;
            }
        }

        private void CreateDepartmentTable_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                // Создаем таблицу Department, если она не существует
                MessageBox.Show("Таблица Department создана (если не существовала).");

            }

        }

        private void ApplyMigrations_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    context.Database.Migrate();
                    MessageBox.Show("Миграции применены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при применении миграций: {ex.Message}");
                }
            }
        }


        private void AddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    //  Можно добавить проверку на DepartmentId
                    if (!context.Departments.Any(d => d.Id == 1))
                    {
                        MessageBox.Show("Отдел с Id = 1 не существует.  Сначала создайте отдел.");
                        return;
                    }

                    var newPerson = new Person { name = "Новое имя", phone = "1234567890", experience = 2, salary = 50000, adress = "Новый адрес", DepartmentId = 1 };
                    context.Persons.Add(newPerson);
                    context.SaveChanges();
                    RefreshDataGrid(); // Вызываем метод для обновления DataGrid

                    MessageBox.Show("Новый сотрудник добавлен.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
                }
            }
        }


        private void InnerJoinQuery_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new ApplicationContext())
            {
                try
                {
                    var query = context.Persons
                    .Join(context.Departments,
                        p => p.DepartmentId,
                        d => d.Id,
                        (p, d) => new { PersonName = p.name, DepartmentName = d.Name })
                    .ToList();

                    QueryDataGrid.ItemsSource = query;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении Inner Join: {ex.Message}");
                }


            }

        }


        private void UpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    var personsToUpdate = context.Persons.Where(p => p.experience > 2).ToList();

                    if (!personsToUpdate.Any())
                    {
                        MessageBox.Show("Нет сотрудников с опытом больше 2 лет.");
                        return;
                    }

                    foreach (var person in personsToUpdate)
                    {
                        person.name = "Updated Name";
                    }

                    context.SaveChanges();
                    RefreshDataGrid();

                    MessageBox.Show("Данные сотрудников обновлены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
                }

            }
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    var personsToDelete = context.Persons.Where(p => p.salary > 60000).ToList();

                    if (!personsToDelete.Any())
                    {
                        MessageBox.Show("Нет сотрудников с зарплатой больше 60000.");
                        return;

                    }

                    context.Persons.RemoveRange(personsToDelete);
                    context.SaveChanges();
                    RefreshDataGrid();

                    MessageBox.Show("Сотрудники удалены.");


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении сотрудников: {ex.Message}");
                }

            }
        }
        private void RefreshDataGrid()
        {
            using (var context = new ApplicationContext())
            {
                QueryDataGrid.ItemsSource = context.Persons.ToList();
            }
        }

    }
}