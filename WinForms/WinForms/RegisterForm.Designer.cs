namespace WinForms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox2 = new TextBox();
            userNameField = new TextBox();
            buttonRegister = new Button();
            passField = new TextBox();
            pictureBox4 = new PictureBox();
            loginField = new TextBox();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            closeButton = new Label();
            MainPanel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(userNameField);
            panel1.Controls.Add(buttonRegister);
            panel1.Controls.Add(passField);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(loginField);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(767, 450);
            panel1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Comic Sans MS", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(456, 164);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(191, 48);
            textBox2.TabIndex = 8;
            // 
            // userNameField
            // 
            userNameField.Font = new Font("Comic Sans MS", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            userNameField.Location = new Point(111, 164);
            userNameField.Name = "userNameField";
            userNameField.Size = new Size(191, 48);
            userNameField.TabIndex = 7;
            userNameField.Enter += userNameField_Enter;
            userNameField.Leave += userNameField_Leave;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = SystemColors.ControlLightLight;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatAppearance.MouseDownBackColor = Color.Silver;
            buttonRegister.FlatAppearance.MouseOverBackColor = Color.LightGray;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRegister.Location = new Point(233, 372);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(231, 41);
            buttonRegister.TabIndex = 6;
            buttonRegister.Text = "Зарегистрировать";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // passField
            // 
            passField.Font = new Font("Comic Sans MS", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passField.Location = new Point(111, 245);
            passField.Name = "passField";
            passField.Size = new Size(191, 48);
            passField.TabIndex = 4;
            passField.UseSystemPasswordChar = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources._lock;
            pictureBox4.Location = new Point(29, 237);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(64, 64);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // loginField
            // 
            loginField.Font = new Font("Comic Sans MS", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginField.Location = new Point(456, 245);
            loginField.Name = "loginField";
            loginField.Size = new Size(191, 48);
            loginField.TabIndex = 2;
            loginField.TextChanged += loginField_TextChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user;
            pictureBox3.Location = new Point(374, 237);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(64, 64);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Controls.Add(closeButton);
            panel2.Controls.Add(MainPanel);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(767, 100);
            panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            closeButton.AutoSize = true;
            closeButton.Cursor = Cursors.Hand;
            closeButton.Dock = DockStyle.Right;
            closeButton.Font = new Font("Century", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(737, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(30, 33);
            closeButton.TabIndex = 1;
            closeButton.Text = "х";
            closeButton.Click += closeButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Font = new Font("Comic Sans MS", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MainPanel.ForeColor = Color.White;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(767, 100);
            MainPanel.TabIndex = 0;
            MainPanel.Text = "Регистрация";
            MainPanel.TextAlign = ContentAlignment.MiddleCenter;
            MainPanel.MouseDown += MainPanel_MouseDown;
            MainPanel.MouseMove += MainPanel_MouseMove;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            Text = "RegisterForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonRegister;
        private Panel panel2;
        private Label closeButton;
        private Label MainPanel;
        private TextBox textBox2;
        private TextBox userNameField;
        private TextBox passField;
        private PictureBox pictureBox4;
        private TextBox loginField;
        private PictureBox pictureBox3;
    }
}