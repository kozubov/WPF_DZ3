using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { set; get; }
    public Person MyPerson { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Persons = new ObservableCollection<Person>
            {
                new Person{ FirstName = "Михаил", Surname="Светлов", Age = "44"},
                new Person{ FirstName = "Сергей", Surname="Есенин", Age = "43"},
                new Person{ FirstName = "Александр", Surname="Пушкин", Age = "42"}
            };
            DataContext = Persons;
            persons_list.ItemsSource = Persons;
        }

        private void Persons_list_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (persons_list.SelectedIndex != -1)
            {
                Name.Text = Persons[persons_list.SelectedIndex].FirstName;
                Surname.Text = Persons[persons_list.SelectedIndex].Surname;
                Age.Text = Persons[persons_list.SelectedIndex].Age;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {

            if (Name.Text == "" || Surname.Text == "" || Age.Text == "")
            {
                MessageBox.Show("Заполните поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                int age = Convert.ToInt32(Age.Text);
                Persons.Add(new Person { FirstName = Name.Text, Surname = Surname.Text, Age = Age.Text });
                Name.Text = null;
                Surname.Text = null;
                Age.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Правильно вводите данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (persons_list.SelectedIndex != -1)
            {
                Persons.RemoveAt(persons_list.SelectedIndex);
                Name.Text = null;
                Surname.Text = null;
                Age.Text = null;
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (persons_list.SelectedIndex != -1)
            {
                if (Name.Text == "" || Surname.Text == "" || Age.Text == "")
                {
                    MessageBox.Show("Введите все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    int Age = Convert.ToInt32(this.Age.Text);
                    Persons[persons_list.SelectedIndex].FirstName = this.Name.Text;
                    Persons[persons_list.SelectedIndex].Surname = this.Surname.Text;
                    Persons[persons_list.SelectedIndex].Age = this.Age.Text;
                    Person s = (Person)this.Resources["stuff"];
                    s.FirstName = this.Name.Text;
                    s.Surname = this.Surname.Text;
                    s.Age = this.Age.Text;

                }
                catch (Exception)
                {
                    MessageBox.Show("Не коректный ввод данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Выберите сотрудника для изменения!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
