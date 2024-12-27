using ControllerLibrary;
using System.Windows.Forms;

namespace WinFormView
{
    public partial class Form1 : Form, IView
    {
        private readonly CalorieController _controller;

        // ����������� ����� � ������������� �����������
        public Form1()
        {
            InitializeComponent(); // ������������� ��������� �����
            _controller = new CalorieController(this); // �������� ����������� � ��������� �������� �������������
        }

        // ����� ��� ����������� ������� ��������� ������������
        public void DisplayMessage(string message)
        {
            lblMessage.ForeColor = System.Drawing.Color.Black; // ��������� ����� ������ � ������
            lblMessage.Text = message; // ����������� ��������� � �������� lblMessage
        }

        // ����� ��� ����������� ������ ������������
        public void DisplayError(string error)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red; // ��������� ����� ������ � �������
            lblMessage.Text = "������: " + error; // ����������� ��������� �� ������ � �������� lblMessage
        }

        // ���������� ������� ������� �� ������ "����������"
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // ��������� ���������� ���� ������������ �� ����������� ������
            string bodyType = cmbBodyType.SelectedItem?.ToString();

            // ���������� ���������� ��� ����, ����� � ��������
            double weight;
            double height;
            int age;

            // ��������� ���������� ���� � ������ ���������� �� ���������� �������
            string gender = cmbGender.SelectedItem?.ToString();
            string activityLevel = cmbActivityLevel.SelectedItem?.ToString();

            // �������� �� ������������� ������������ �����
            if (string.IsNullOrEmpty(bodyType) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(activityLevel))
            {
                DisplayError("��������� ��� ������������ ����."); // ����� ��������� �� ������
                return; // ����������� ���������� ������
            }

            // �������� ������������ ��������� ����
            if (!double.TryParse(txtWeight.Text, out weight) || weight <= 0)
            {
                DisplayError("������� ���������� ���."); // ����� ��������� �� ������
                return; // ����������� ���������� ������
            }

            // �������� ������������ ��������� �����
            if (!double.TryParse(txtHeight.Text, out height) || height <= 0)
            {
                DisplayError("������� ���������� ����."); // ����� ��������� �� ������
                return; // ����������� ���������� ������
            }

            // �������� ������������ ��������� ��������
            if (!int.TryParse(txtAge.Text, out age) || age <= 0)
            {
                DisplayError("������� ���������� �������."); // ����� ��������� �� ������
                return; // ����������� ���������� ������
            }

            // ��������� ���� ������������ ����� ����������
            _controller.SetBodyType(bodyType);

            // ������ ������� ����� ����������
            _controller.CalculateCalories(weight, height, age, gender, activityLevel);
        }

    }
}
