using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace pr8_Validation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Training> _trainings = new List<Training>();
        private const string FilePath = "trainings.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                _trainings = JsonSerializer.Deserialize<List<Training>>(json) ?? new List<Training>();
            }
            TrainingList.ItemsSource = _trainings;
            UpdateStatus();
        }
        private void SaveData()
        {
            string json = JsonSerializer.Serialize(_trainings);
            File.WriteAllText(FilePath, json);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            StatusText.Text = "Записано тренировок: " + _trainings.Count;
        }

        private void AddTraining_Click(object sender, RoutedEventArgs e)
        {
            var form = new TrainingForm();
            if (form.ShowDialog() == true)
            {
                _trainings.Add(form.TrainingData);
                SaveData();
                TrainingList.Items.Refresh();
            }
        }

        private void EditTraining_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingList.SelectedItem is Training selected)
            {
                var form = new TrainingForm(selected);
                if (form.ShowDialog() == true)
                {
                    int index = _trainings.IndexOf(selected);
                    _trainings[index] = form.TrainingData;
                    SaveData();
                    TrainingList.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите тренировку.");
            }
        }

        private void DeleteTraining_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingList.SelectedItem is Training selected)
            {
                var result = MessageBox.Show("Удалить эту тренировку?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _trainings.Remove(selected);
                    SaveData();
                    TrainingList.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите тренировку.");
            }
        }
    }
}