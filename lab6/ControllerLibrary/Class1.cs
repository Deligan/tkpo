using ModelLibrary; // Подключение пространства имён, содержащего модели для расчётов

namespace ControllerLibrary // Определение пространства имён для контроллера
{
    // Интерфейс представления, определяющий методы взаимодействия с пользователем
    public interface IView
    {
        // Метод для отображения обычных сообщений
        void DisplayMessage(string message);

        // Метод для отображения ошибок
        void DisplayError(string error);
    }

    // Класс контроллера для управления расчётом калорий
    public class CalorieController
    {
        private readonly PhysicalActivity _physicalActivity; // Поле для учёта физической активности
        private IBodyType _bodyTypeModel; // Поле для хранения текущей модели телосложения
        private readonly IView _view; // Поле для представления

        // Конструктор, принимающий интерфейс представления
        public CalorieController(IView view)
        {
            _physicalActivity = new PhysicalActivity(); // Инициализация объекта для работы с физической активностью
            _view = view; // Сохранение переданного представления
        }

        // Метод для установки типа телосложения
        public void SetBodyType(string bodyType)
        {
            try
            {
                // Установка модели телосложения на основе переданной строки
                _bodyTypeModel = bodyType.ToLower() switch
                {
                    "asthenic" => new Asthenic(), // Для типа "asthenic" создаём модель Asthenic
                    "normostenic" => new Normostenic(), // Для типа "normostenic" создаём модель Normostenic
                    "hypersthenic" => new Hypersthenic(), // Для типа "hypersthenic" создаём модель Hypersthenic
                    _ => throw new ArgumentException("Invalid body type") // Исключение для неверного типа
                };

                // Уведомление пользователя об успешной установке типа телосложения
                _view.DisplayMessage($"Тип телосложения установлен: {bodyType}");
            }
            catch (Exception ex)
            {
                // Обработка ошибок и отображение сообщения об ошибке
                _view.DisplayError(ex.Message);
            }
        }

        // Метод для расчёта калорий
        public void CalculateCalories(double weight, double height, int age, string gender, string activityLevel)
        {
            try
            {
                // Проверка, установлен ли тип телосложения
                if (_bodyTypeModel == null)
                {
                    throw new InvalidOperationException("Тип телосложения не установлен.");
                }

                // Расчёт базового уровня калорий на основе типа телосложения
                double baseCalories = _bodyTypeModel.CalculateCalories(weight, height, age, gender);

                // Корректировка калорий с учётом уровня физической активности
                double dailyCalories = _physicalActivity.AdjustCaloriesForActivity(baseCalories, activityLevel);

                // Вывод итогового сообщения с расчётом калорий
                _view.DisplayMessage($"Ваша дневная норма калорий: {dailyCalories:F2} ккал");
            }
            catch (Exception ex)
            {
                // Обработка ошибок и отображение сообщения об ошибке
                _view.DisplayError(ex.Message);
            }
        }
    }
}
