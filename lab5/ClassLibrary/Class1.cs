using System; // Подключение пространства имен для стандартных классов C#, включая консольный ввод/вывод и делегаты.

namespace ClassLibrary // Определение пространства имен для логики банкомата.
{
    // Определение интерфейса для состояний банкомата.
    public interface IAtmState
    {
        // Метод для обработки ввода PIN-кода.
        void EnterPin(AtmMachine machine, string pin);

        // Метод для выполнения транзакций.
        void ExecuteTransaction(AtmMachine machine, string transactionType, int amount = 0);

        // Метод для пополнения наличных в банкомате.
        void RefillCash(AtmMachine machine, int amount);
    }

    // Класс, представляющий банкомат.
    public class AtmMachine
    {
        public int MachineId { get; set; } // Уникальный идентификатор банкомата.
        public IAtmState CurrentState { get; set; } // Текущее состояние банкомата.
        public int AvailableCash { get; set; } // Количество доступных наличных в банкомате.
        public bool IsOnline { get; set; } // Статус соединения банкомата с сервером.
        public double ConnectionFailureRate { get; set; } // Вероятность сбоя соединения.
        private static Random random = new Random(); // Генератор случайных чисел для симуляции сбоев связи.

        public Action<string> Alert { get; set; } // Делегат для уведомлений, принимающий строку.

        // Конструктор для инициализации банкомата.
        public AtmMachine(int machineId, int initialCash, bool isOnline, double connectionFailureRate)
        {
            MachineId = machineId; // Присваиваем ID.
            AvailableCash = initialCash; // Устанавливаем начальный баланс наличных.
            IsOnline = isOnline; // Устанавливаем статус соединения.
            ConnectionFailureRate = connectionFailureRate; // Задаем вероятность сбоя соединения.
            CurrentState = new IdleState(); // Устанавливаем начальное состояние (режим ожидания).
        }

        // Метод для передачи ввода PIN-кода в текущее состояние.
        public void EnterPin(string pin) => CurrentState.EnterPin(this, pin);

        // Метод для выполнения транзакций (например, снятие или выход).
        public void ExecuteTransaction(string transactionType, int amount = 0)
        {
            SimulateConnectionIssue(); // Проверяем возможный сбой соединения.
            CurrentState.ExecuteTransaction(this, transactionType, amount); // Передаем транзакцию текущему состоянию.
        }

        // Метод для пополнения наличных.
        public void RefillCash(int amount) => CurrentState.RefillCash(this, amount);

        // Метод для симуляции сбоев связи.
        private void SimulateConnectionIssue()
        {
            if (random.NextDouble() < ConnectionFailureRate) // Если случайное число меньше вероятности сбоя.
            {
                IsOnline = false; // Отключаем соединение.
            }
        }
    }

    // Состояние ожидания (Idle).
    public class IdleState : IAtmState
    {
        // Ввод PIN-кода из режима ожидания.
        public void EnterPin(AtmMachine machine, string pin)
        {
            machine.Alert?.Invoke("Ввод PIN-кода. Переход к аутентификации.");
            machine.CurrentState = new AuthenticatingState(); // Меняем состояние на "аутентификация".
            machine.CurrentState.EnterPin(machine, pin); // Передаем PIN-код новому состоянию.
        }

        // Транзакции недоступны в режиме ожидания.
        public void ExecuteTransaction(AtmMachine machine, string transactionType, int amount = 0)
        {
            machine.Alert?.Invoke("Пожалуйста, сначала введите PIN-код.");
        }

        // Пополнение недоступно в режиме ожидания.
        public void RefillCash(AtmMachine machine, int amount)
        {
            machine.Alert?.Invoke("Невозможно пополнить банкомат в режиме ожидания.");
        }
    }

    // Состояние аутентификации.
    public class AuthenticatingState : IAtmState
    {
        // Проверка PIN-кода.
        public void EnterPin(AtmMachine machine, string pin)
        {
            if (pin == "1234") // Если PIN-код правильный.
            {
                machine.Alert?.Invoke("PIN-код верен. Переход к выполнению операций.");
                machine.CurrentState = new ActiveState(); // Переходим в активное состояние.
            }
            else // Если PIN-код неверный.
            {
                machine.Alert?.Invoke("Неверный PIN-код. Возврат в режим ожидания.");
                machine.CurrentState = new IdleState(); // Возвращаемся в режим ожидания.
            }
        }

        // Транзакции недоступны во время аутентификации.
        public void ExecuteTransaction(AtmMachine machine, string transactionType, int amount = 0)
        {
            machine.Alert?.Invoke("Аутентификация ещё не завершена.");
        }

        // Пополнение недоступно во время аутентификации.
        public void RefillCash(AtmMachine machine, int amount)
        {
            machine.Alert?.Invoke("Невозможно пополнить банкомат во время аутентификации.");
        }
    }

    // Активное состояние.
    public class ActiveState : IAtmState
    {
        // Повторный ввод PIN-кода в активном состоянии.
        public void EnterPin(AtmMachine machine, string pin)
        {
            machine.Alert?.Invoke("Вы уже вошли в систему. Выполните операцию или завершите работу.");
        }

        // Выполнение транзакции.
        public void ExecuteTransaction(AtmMachine machine, string transactionType, int amount = 0)
        {
            if (!machine.IsOnline) // Если банкомат не подключен.
            {
                machine.Alert?.Invoke("Ошибка связи. Банкомат заблокирован.");
                machine.CurrentState = new LockedState(); // Переходим в заблокированное состояние.
                return;
            }

            switch (transactionType.ToLower()) // Определяем тип транзакции.
            {
                case "withdraw": // Снятие наличных.
                    if (amount <= machine.AvailableCash && amount > 0) // Если достаточно средств.
                    {
                        machine.AvailableCash -= amount; // Снимаем сумму.
                        machine.Alert?.Invoke($"Снято {amount}. Остаток в банкомате: {machine.AvailableCash}.");

                        if (machine.AvailableCash <= 0) // Если деньги закончились.
                        {
                            machine.Alert?.Invoke("Деньги закончились. Банкомат заблокирован.");
                            machine.CurrentState = new LockedState(); // Переходим в заблокированное состояние.
                        }
                    }
                    else
                    {
                        machine.Alert?.Invoke("Недостаточно средств или неверная сумма.");
                    }
                    break;
                case "exit": // Завершение работы.
                    machine.Alert?.Invoke("Завершение работы. Переход в режим ожидания.");
                    machine.CurrentState = new IdleState(); // Возвращаемся в режим ожидания.
                    break;
                default: // Неизвестная операция.
                    machine.Alert?.Invoke("Неизвестная операция. Попробуйте снова.");
                    break;
            }
        }

        // Пополнение недоступно в активном состоянии.
        public void RefillCash(AtmMachine machine, int amount)
        {
            machine.Alert?.Invoke("Невозможно пополнить банкомат во время выполнения операций.");
        }
    }

    // Заблокированное состояние.
    public class LockedState : IAtmState
    {
        // Ввод PIN-кода невозможен.
        public void EnterPin(AtmMachine machine, string pin)
        {
            machine.Alert?.Invoke("Банкомат заблокирован. Операции невозможны.");
        }

        // Выполнение транзакции невозможно.
        public void ExecuteTransaction(AtmMachine machine, string transactionType, int amount = 0)
        {
            machine.Alert?.Invoke("Банкомат заблокирован. Операции невозможны.");
        }

        // Пополнение возможно и может разблокировать банкомат.
        public void RefillCash(AtmMachine machine, int amount)
        {
            machine.AvailableCash += amount; // Пополняем баланс.
            machine.Alert?.Invoke($"Банкомат пополнен. Доступно: {machine.AvailableCash}.");

            if (machine.IsOnline && machine.AvailableCash > 0) // Если соединение восстановлено и есть средства.
            {
                machine.Alert?.Invoke("Банкомат разблокирован. Переход в режим ожидания.");
                machine.CurrentState = new IdleState(); // Переходим в режим ожидания.
            }
        }
    }
}
