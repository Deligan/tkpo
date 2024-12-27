using ControllerLibrary; // Подключение пространства имён, содержащего контроллеры

namespace ConsoleView // Пространство имён для реализации консольного интерфейса
{
    // Класс для консольного представления, реализует интерфейс IView
    public class ConsoleView : IView
    {
        // Метод для отображения сообщений в консоли
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message); // Вывод сообщения
        }

        // Метод для отображения ошибок в консоли
        public void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red; // Установка красного цвета текста для ошибок
            Console.WriteLine($"Ошибка: {error}"); // Вывод сообщения об ошибке
            Console.ResetColor(); // Сброс цвета текста
        }

        // Метод для запроса ввода от пользователя
        public string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt); // Вывод подсказки
            return Console.ReadLine(); // Чтение ввода пользователя
        }

        // Метод для получения корректного ввода с валидацией и повтором при ошибке
        public string GetValidUserInput(string prompt, Func<string, bool> validate, string errorMessage)
        {
            string input;
            do
            {
                input = GetUserInput(prompt); // Получение ввода от пользователя
                if (!validate(input)) // Проверка ввода с использованием функции валидации
                {
                    DisplayError(errorMessage); // Сообщение об ошибке, если ввод некорректен
                }
            } while (!validate(input)); // Повтор, пока ввод не станет корректным

            return input; // Возвращение корректного ввода
        }

        // Метод для получения корректного числового ввода с проверкой
        public double GetValidDoubleInput(string prompt, Func<double, bool> validate, string errorMessage)
        {
            double value;
            do
            {
                string input = GetUserInput(prompt); // Получение ввода от пользователя
                if (double.TryParse(input, out value) && validate(value)) // Проверка, что ввод можно преобразовать в число и проходит валидацию
                {
                    break; // Прекращение цикла при корректном вводе
                }
                else
                {
                    DisplayError(errorMessage); // Сообщение об ошибке
                }
            } while (true); // Бесконечный цикл, пока ввод не станет корректным

            return value; // Возвращение корректного значения
        }

        // Метод для получения корректного целочисленного ввода с проверкой
        public int GetValidIntInput(string prompt, Func<int, bool> validate, string errorMessage)
        {
            int value;
            do
            {
                string input = GetUserInput(prompt); // Получение ввода от пользователя
                if (int.TryParse(input, out value) && validate(value)) // Проверка, что ввод можно преобразовать в целое число и проходит валидацию
                {
                    break; // Прекращение цикла при корректном вводе
                }
                else
                {
                    DisplayError(errorMessage); // Сообщение об ошибке
                }
            } while (true); // Бесконечный цикл, пока ввод не станет корректным

            return value; // Возвращение корректного значения
        }

        // Метод для запуска процесса взаимодействия с пользователем
        public void Run(CalorieController controller)
        {
            // Запрос типа телосложения с проверкой
            string bodyType = GetValidUserInput("Введите тип телосложения (asthenic, normostenic, hypersthenic):",
                input => input == "asthenic" || input == "normostenic" || input == "hypersthenic",
                "Неверно введён тип телосложения. Используйте: asthenic, normostenic, hypersthenic.");
            controller.SetBodyType(bodyType); // Установка типа телосложения

            // Запрос веса с проверкой
            double weight = GetValidDoubleInput("Введите вес (кг):", value => value > 0 & value < 400, "Такого веса не существует.");

            // Запрос роста с проверкой
            double height = GetValidDoubleInput("Введите рост (см):", value => value > 0 & value < 300, "Такого роста не существует. Возможно вы не человек");

            // Запрос возраста с проверкой
            int age = GetValidIntInput("Введите возраст:", value => value > 0 & value < 100, "Такого возраста не существует.");

            // Запрос пола с проверкой
            string gender = GetValidUserInput("Введите пол (male/female):", input => input == "male" || input == "female", "Пол должен быть 'male' или 'female'.");

            // Запрос уровня активности с проверкой
            string activityLevel = GetValidUserInput("Введите уровень активности (low, medium, high):", input => input == "low" || input == "medium" || input == "high", "Неверный уровень активности. Используйте: low, medium, high.");

            // Расчёт и отображение калорий
            controller.CalculateCalories(weight, height, age, gender, activityLevel);
        }
    }

    // Основной класс программы
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleView view = new ConsoleView(); // Создание экземпляра консольного представления
            CalorieController controller = new CalorieController(view); // Создание экземпляра контроллера с представлением

            // Запуск процесса в представлении
            view.Run(controller); // Запуск взаимодействия с пользователем
        }
    }
}