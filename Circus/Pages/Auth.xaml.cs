using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Circus.Data;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        CirkEntities CirkEntities { get; set; }

        Employee Employee { get; set; }

        public Auth()
        {
            InitializeComponent();
            CirkEntities = new CirkEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee = CirkEntities.Employee.ToList().Where(x => x.Login == LogT.Text && x.Password == PassB.Password).FirstOrDefault();

            var admin = CirkEntities.Role.ToList().Where(x => x.RoleId == Employee.RoleId).FirstOrDefault();

            if (admin != null)
            {
                if (LogT.Text == "")
                {
                    System.Windows.MessageBox.Show("Заполните логин.");
                }
                else
                {
                    if (PassB.Password == "")
                    {
                        System.Windows.MessageBox.Show("Заполните пароль.");
                    }
                    else
                    {
                        NavigationService.Navigate(new AdminPage());
                    }
                }
            }
        }
    }
}
