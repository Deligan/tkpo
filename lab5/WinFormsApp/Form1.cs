using ClassLibrary; // Подключение библиотеки с логикой работы банкомата

namespace WinFormsApp
{
    public partial class Form1 : Form // Основной класс формы, унаследован от базового класса Form
    {
        private AtmMachine atmMachine; // Поле для хранения объекта банкомата

        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы
            atmMachine = new AtmMachine(1, 10000, true, 0.05); // Создание объекта банкомата с уникальным ID, начальными деньгами, статусом онлайн и шансом сбоя
            atmMachine.Alert = message => lblStatus.Text = message; // Установка обработчика событий Alert для отображения сообщений в метке lblStatus
        }

        private void btnEnterPin_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text; // Получение введенного пользователем PIN-кода из текстового поля txtPin
            atmMachine.EnterPin(pin); // Передача PIN-кода банкомату для обработки
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out int amount)) // Проверка корректности введенной суммы
            {
                atmMachine.ExecuteTransaction("withdraw", amount); // Попытка снять указанную сумму через банкомат
            }
            else
            {
                MessageBox.Show("Введите корректную сумму."); // Сообщение об ошибке при некорректном вводе
            }
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out int amount)) // Проверка корректности введенной суммы
            {
                atmMachine.RefillCash(amount); // Пополнение банкомата указанной суммой
            }
            else
            {
                MessageBox.Show("Введите корректную сумму."); // Сообщение об ошибке при некорректном вводе
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            atmMachine.ExecuteTransaction("exit"); // Завершение работы и переход банкомата в режим ожидания
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Банкомат в режиме ожидания."; // Установка начального статуса банкомата при загрузке формы
        }
    }
}
