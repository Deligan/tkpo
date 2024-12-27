using ControllerLibrary;
using System.Windows.Forms;

namespace WinFormView
{
    public partial class Form1 : Form, IView
    {
        private readonly CalorieController _controller;

        // Конструктор формы и инициализация контроллера
        public Form1()
        {
            InitializeComponent(); // Инициализация элементов формы
            _controller = new CalorieController(this); // Создание контроллера с передачей текущего представления
        }

        // Метод для отображения обычных сообщений пользователю
        public void DisplayMessage(string message)
        {
            lblMessage.ForeColor = System.Drawing.Color.Black; // Установка цвета текста в чёрный
            lblMessage.Text = message; // Отображение сообщения в элементе lblMessage
        }

        // Метод для отображения ошибок пользователю
        public void DisplayError(string error)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red; // Установка цвета текста в красный
            lblMessage.Text = "Ошибка: " + error; // Отображение сообщения об ошибке в элементе lblMessage
        }

        // Обработчик события нажатия на кнопку "Рассчитать"
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Получение выбранного типа телосложения из выпадающего списка
            string bodyType = cmbBodyType.SelectedItem?.ToString();

            // Объявление переменных для веса, роста и возраста
            double weight;
            double height;
            int age;

            // Получение выбранного пола и уровня активности из выпадающих списков
            string gender = cmbGender.SelectedItem?.ToString();
            string activityLevel = cmbActivityLevel.SelectedItem?.ToString();

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrEmpty(bodyType) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(activityLevel))
            {
                DisplayError("Заполните все обязательные поля."); // Вывод сообщения об ошибке
                return; // Прекращение выполнения метода
            }

            // Проверка корректности введённого веса
            if (!double.TryParse(txtWeight.Text, out weight) || weight <= 0)
            {
                DisplayError("Введите корректный вес."); // Вывод сообщения об ошибке
                return; // Прекращение выполнения метода
            }

            // Проверка корректности введённого роста
            if (!double.TryParse(txtHeight.Text, out height) || height <= 0)
            {
                DisplayError("Введите корректный рост."); // Вывод сообщения об ошибке
                return; // Прекращение выполнения метода
            }

            // Проверка корректности введённого возраста
            if (!int.TryParse(txtAge.Text, out age) || age <= 0)
            {
                DisplayError("Введите корректный возраст."); // Вывод сообщения об ошибке
                return; // Прекращение выполнения метода
            }

            // Установка типа телосложения через контроллер
            _controller.SetBodyType(bodyType);

            // Расчёт калорий через контроллер
            _controller.CalculateCalories(weight, height, age, gender, activityLevel);
        }

    }
}
