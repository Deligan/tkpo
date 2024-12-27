namespace WinFormView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbBodyType = new ComboBox();
            txtWeight = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtHeight = new TextBox();
            label3 = new Label();
            txtAge = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cmbGender = new ComboBox();
            label6 = new Label();
            cmbActivityLevel = new ComboBox();
            btnCalculate = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // cmbBodyType
            // 
            cmbBodyType.FormattingEnabled = true;
            cmbBodyType.Items.AddRange(new object[] { "Asthenic", "Normostenic", "Hypersthenic" });
            cmbBodyType.Location = new Point(26, 42);
            cmbBodyType.Name = "cmbBodyType";
            cmbBodyType.Size = new Size(151, 28);
            cmbBodyType.TabIndex = 0;
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(26, 115);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(149, 27);
            txtWeight.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 92);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 2;
            label1.Text = "Вес ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 164);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 4;
            label2.Text = "Рост ";
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(26, 187);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(149, 27);
            txtHeight.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 19);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 6;
            label3.Text = "Возраст ";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(258, 42);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(149, 27);
            txtAge.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 19);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 7;
            label4.Text = "Тип телосложения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(259, 92);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 9;
            label5.Text = "Пол ";
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.Location = new Point(258, 114);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(151, 28);
            cmbGender.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(258, 164);
            label6.Name = "label6";
            label6.Size = new Size(151, 20);
            label6.TabIndex = 11;
            label6.Text = "Уровень активности";
            // 
            // cmbActivityLevel
            // 
            cmbActivityLevel.FormattingEnabled = true;
            cmbActivityLevel.Items.AddRange(new object[] { "Low", "Medium", "High" });
            cmbActivityLevel.Location = new Point(258, 187);
            cmbActivityLevel.Name = "cmbActivityLevel";
            cmbActivityLevel.Size = new Size(151, 28);
            cmbActivityLevel.TabIndex = 10;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(159, 242);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 27);
            btnCalculate.TabIndex = 12;
            btnCalculate.Text = "Рассчитать";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(29, 285);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(67, 20);
            lblMessage.TabIndex = 13;
            lblMessage.Text = "Message";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 334);
            Controls.Add(lblMessage);
            Controls.Add(btnCalculate);
            Controls.Add(label6);
            Controls.Add(cmbActivityLevel);
            Controls.Add(label5);
            Controls.Add(cmbGender);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtAge);
            Controls.Add(label2);
            Controls.Add(txtHeight);
            Controls.Add(label1);
            Controls.Add(txtWeight);
            Controls.Add(cmbBodyType);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBodyType;
        private TextBox txtWeight;
        private Label label1;
        private Label label2;
        private TextBox txtHeight;
        private Label label3;
        private TextBox txtAge;
        private Label label4;
        private Label label5;
        private ComboBox cmbGender;
        private Label label6;
        private ComboBox cmbActivityLevel;
        private Button btnCalculate;
        private Label lblMessage;
    }
}
