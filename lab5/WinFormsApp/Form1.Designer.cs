namespace WinFormsApp
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
            txtPin = new TextBox();
            txtAmount = new TextBox();
            btnEnterPin = new Button();
            btnWithdraw = new Button();
            btnRefill = new Button();
            btnExit = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // txtPin
            // 
            txtPin.Location = new Point(30, 48);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(125, 27);
            txtPin.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(30, 118);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(125, 27);
            txtAmount.TabIndex = 1;
            // 
            // btnEnterPin
            // 
            btnEnterPin.Location = new Point(202, 55);
            btnEnterPin.Name = "btnEnterPin";
            btnEnterPin.Size = new Size(149, 29);
            btnEnterPin.TabIndex = 2;
            btnEnterPin.Text = "ввод PIN-кода";
            btnEnterPin.UseVisualStyleBackColor = true;
            btnEnterPin.Click += btnEnterPin_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(202, 118);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(149, 29);
            btnWithdraw.TabIndex = 3;
            btnWithdraw.Text = "снять деньги";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnRefill
            // 
            btnRefill.Location = new Point(30, 195);
            btnRefill.Name = "btnRefill";
            btnRefill.Size = new Size(197, 29);
            btnRefill.TabIndex = 4;
            btnRefill.Text = "пополнить банкомат";
            btnRefill.UseVisualStyleBackColor = true;
            btnRefill.Click += btnRefill_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(30, 250);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(197, 29);
            btnExit.TabIndex = 5;
            btnExit.Text = "завершение работы";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(468, 55);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 343);
            Controls.Add(lblStatus);
            Controls.Add(btnExit);
            Controls.Add(btnRefill);
            Controls.Add(btnWithdraw);
            Controls.Add(btnEnterPin);
            Controls.Add(txtAmount);
            Controls.Add(txtPin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPin;
        private TextBox txtAmount;
        private Button btnEnterPin;
        private Button btnWithdraw;
        private Button btnRefill;
        private Button btnExit;
        private Label lblStatus;
    }
}
