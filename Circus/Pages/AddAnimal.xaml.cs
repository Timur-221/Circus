using Circus.Data;
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
    /// Логика взаимодействия для AddAnimal.xaml
    /// </summary>
    public partial class AddAnimal : Page
    {
        CirkEntities CirkEntities { get; set; }

        Animal Animal { get; set; }
        public AddAnimal()
        {
            InitializeComponent();
            CirkEntities = new CirkEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var animal = new Animal
            {
                Name = NameB.Text,
                Weight = Convert.ToInt32(WeightB.Text),
                Gender = GenderB.Text,
                PreferenceInFood = eatB.Text,
            };

            CirkEntities.Animal.Add(animal);
            CirkEntities.SaveChanges();
            
            MessageBox.Show("Зверюга успешно добавилаь!");

            NavigationService.Navigate(new AddAnimal());
        }
    }
}
