using ClassLibrary; // ����������� ���������� � ������� ������ ���������

namespace WinFormsApp
{
    public partial class Form1 : Form // �������� ����� �����, ����������� �� �������� ������ Form
    {
        private AtmMachine atmMachine; // ���� ��� �������� ������� ���������

        public Form1()
        {
            InitializeComponent(); // ������������� ����������� �����
            atmMachine = new AtmMachine(1, 10000, true, 0.05); // �������� ������� ��������� � ���������� ID, ���������� ��������, �������� ������ � ������ ����
            atmMachine.Alert = message => lblStatus.Text = message; // ��������� ����������� ������� Alert ��� ����������� ��������� � ����� lblStatus
        }

        private void btnEnterPin_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text; // ��������� ���������� ������������� PIN-���� �� ���������� ���� txtPin
            atmMachine.EnterPin(pin); // �������� PIN-���� ��������� ��� ���������
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out int amount)) // �������� ������������ ��������� �����
            {
                atmMachine.ExecuteTransaction("withdraw", amount); // ������� ����� ��������� ����� ����� ��������
            }
            else
            {
                MessageBox.Show("������� ���������� �����."); // ��������� �� ������ ��� ������������ �����
            }
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out int amount)) // �������� ������������ ��������� �����
            {
                atmMachine.RefillCash(amount); // ���������� ��������� ��������� ������
            }
            else
            {
                MessageBox.Show("������� ���������� �����."); // ��������� �� ������ ��� ������������ �����
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            atmMachine.ExecuteTransaction("exit"); // ���������� ������ � ������� ��������� � ����� ��������
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "�������� � ������ ��������."; // ��������� ���������� ������� ��������� ��� �������� �����
        }
    }
}
