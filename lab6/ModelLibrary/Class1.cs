namespace ModelLibrary
{
    // Интерфейс расчёта калорий для типа телосложения
    public interface IBodyType
    {
        // Метод для расчёта базового уровня калорий
        double CalculateCalories(double weight, double height, int age, string gender);
    }

    // Тип телосложения: Астеник
    public class Asthenic : IBodyType
    {
        // Реализация метода расчёта калорий для астеников
        public double CalculateCalories(double weight, double height, int age, string gender)
        {
            // Общая формула расчёта калорий
            double baseCalories = (10 * weight) + (6.25 * height) - (5 * age);
            // Коррекция результата в зависимости от пола
            return gender.ToLower() == "male" ? baseCalories + 5 - 100 : baseCalories - 161 - 100;
        }
    }

    // Тип телосложения: Нормостеник
    public class Normostenic : IBodyType
    {
        // Реализация метода расчёта калорий для нормостеников
        public double CalculateCalories(double weight, double height, int age, string gender)
        {
            double baseCalories = (10 * weight) + (6.25 * height) - (5 * age);
            return gender.ToLower() == "male" ? baseCalories + 5 : baseCalories - 161;
        }
    }

    // Тип телосложения: Гиперстеник
    public class Hypersthenic : IBodyType
    {
        // Реализация метода расчёта калорий для гиперстеников
        public double CalculateCalories(double weight, double height, int age, string gender)
        {
            double baseCalories = (10 * weight) + (6.25 * height) - (5 * age);
            return gender.ToLower() == "male" ? baseCalories + 5 + 100 : baseCalories - 161 + 100;
        }
    }

    // Класс физической активности
    public class PhysicalActivity
    {
        // Метод для коррекции калорий в зависимости от уровня активности
        public double AdjustCaloriesForActivity(double baseCalories, string activityLevel)
        {
            // Используется конструкция switch для выбора коэффициента активности
            return activityLevel.ToLower() switch
            {
                "low" => baseCalories * 1.2,    // Низкая активность
                "medium" => baseCalories * 1.55, // Средняя активность
                "high" => baseCalories * 1.9,   // Высокая активность
                _ => throw new ArgumentException("Invalid activity level") // Ошибка при некорректном вводе
            };
        }
    }

    
}
