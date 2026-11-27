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
using System.Windows.Shapes;

namespace pr8_Validation
{
    /// <summary>
    /// Логика взаимодействия для TrainingForm.xaml
    /// </summary>
    public partial class TrainingForm : Window
    {
        public Training TrainingData { get; private set; }

        public TrainingForm()
        {
            InitializeComponent();

            TrainingData = new Training { Date = DateTime.Now };
            DataContext = TrainingData;
            HeaderText.Text = "Создание записи";
        }
        public TrainingForm(Training training) : this()
        {
            TrainingData = new Training
            {
                Date = training.Date,
                Type = training.Type,
                Duration = training.Duration,
                Load = training.Load,
                Description = training.Description
            };
            DataContext = TrainingData;
            HeaderText.Text = "Редактирование записи";
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что нет ошибок валидации
            if (Validation.GetHasError(DatePickerTraining) || Validation.GetHasError(ComboBoxTraining) || Validation.GetHasError(TextBoxDuraction) || Validation.GetHasError(TextBoxLoad))
            {
                MessageBox.Show("Исправьте ошибки в форме.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
