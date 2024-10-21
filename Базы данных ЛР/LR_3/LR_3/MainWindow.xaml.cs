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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Query1_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var query1 = context.Persons
                    .Select(u => new { u.name, u.phone, u.salary })
                    .ToList();

                // Отображаем результат в DataGrid
                QueryDataGrid.ItemsSource = query1;
            }
        }

        private void Query2_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var query2 = context.Persons
                    .OrderBy(u => u.adress)
                    .Select(u => new { u.name, u.adress })
                    .ToList();

                // Отображаем результат в DataGrid
                QueryDataGrid.ItemsSource = query2;
            }
        }

        private void Query3_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var query3 = context.Persons
                    .Where(u => u.experience > 4)
                    .Select(u => new { u.name, u.experience })
                    .ToList();

                // Отображаем результат в DataGrid
                QueryDataGrid.ItemsSource = query3;
            }
        }
    }
}