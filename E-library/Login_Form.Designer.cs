namespace E_library
{
    partial class Login_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.Password_textbox = new System.Windows.Forms.TextBox();
            this.Login_textbox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Login_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.Guest_checkbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Signup_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Password_textbox
            // 
            this.Password_textbox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Password_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password_textbox.Location = new System.Drawing.Point(114, 57);
            this.Password_textbox.Name = "Password_textbox";
            this.Password_textbox.PasswordChar = '*';
            this.Password_textbox.Size = new System.Drawing.Size(193, 29);
            this.Password_textbox.TabIndex = 8;
            // 
            // Login_textbox
            // 
            this.Login_textbox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Login_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login_textbox.Location = new System.Drawing.Point(87, 18);
            this.Login_textbox.Name = "Login_textbox";
            this.Login_textbox.Size = new System.Drawing.Size(221, 29);
            this.Login_textbox.TabIndex = 7;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password_label.Location = new System.Drawing.Point(27, 60);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(81, 24);
            this.Password_label.TabIndex = 6;
            this.Password_label.Text = "Пароль:";
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login_label.Location = new System.Drawing.Point(27, 19);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(62, 24);
            this.Login_label.TabIndex = 5;
            this.Login_label.Text = "Логін:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "___________________________________________________";
            // 
            // Login_button
            // 
            this.Login_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_button.Location = new System.Drawing.Point(0, 145);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(150, 47);
            this.Login_button.TabIndex = 10;
            this.Login_button.Text = "Увійти";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Guest_checkbox
            // 
            this.Guest_checkbox.AutoSize = true;
            this.Guest_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Guest_checkbox.Location = new System.Drawing.Point(6, 106);
            this.Guest_checkbox.Name = "Guest_checkbox";
            this.Guest_checkbox.Size = new System.Drawing.Size(139, 28);
            this.Guest_checkbox.TabIndex = 12;
            this.Guest_checkbox.Text = "Права гостя";
            this.Guest_checkbox.UseVisualStyleBackColor = true;
            this.Guest_checkbox.CheckedChanged += new System.EventHandler(this.Guest_checkbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "___________________________________________________";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Signup_button
            // 
            this.Signup_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Signup_button.Location = new System.Drawing.Point(158, 145);
            this.Signup_button.Name = "Signup_button";
            this.Signup_button.Size = new System.Drawing.Size(150, 47);
            this.Signup_button.TabIndex = 14;
            this.Signup_button.Text = "Зареєструватися";
            this.Signup_button.UseVisualStyleBackColor = true;
            this.Signup_button.Click += new System.EventHandler(this.Signup_button_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Exit_button.Location = new System.Drawing.Point(0, 199);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(308, 47);
            this.Exit_button.TabIndex = 15;
            this.Exit_button.Text = "Вийти";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::E_library.Properties.Resources.Key;
            this.pictureBox3.Location = new System.Drawing.Point(1, 59);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::E_library.Properties.Resources.User;
            this.pictureBox2.Location = new System.Drawing.Point(1, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::E_library.Properties.Resources.Splash_books;
            this.pictureBox1.Location = new System.Drawing.Point(312, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(640, 253);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Signup_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Guest_checkbox);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password_textbox);
            this.Controls.Add(this.Login_textbox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вікно входу";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Password_textbox;
        private System.Windows.Forms.TextBox Login_textbox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.CheckBox Guest_checkbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Signup_button;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

