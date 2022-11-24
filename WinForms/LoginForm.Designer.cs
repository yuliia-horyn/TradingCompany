
namespace WinForms
{
    partial class LoginForm
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
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.Label1Login = new System.Windows.Forms.Label();
            this.Label2Password = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLoginCancel = new System.Windows.Forms.Button();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.linkLabelForgot = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(104, 71);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(255, 22);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLogin_KeyPress);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(104, 155);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(255, 22);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // Label1Login
            // 
            this.Label1Login.AutoSize = true;
            this.Label1Login.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1Login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label1Login.Location = new System.Drawing.Point(181, 37);
            this.Label1Login.Name = "Label1Login";
            this.Label1Login.Size = new System.Drawing.Size(76, 31);
            this.Label1Login.TabIndex = 2;
            this.Label1Login.Text = "Login";
            // 
            // Label2Password
            // 
            this.Label2Password.AutoSize = true;
            this.Label2Password.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2Password.Location = new System.Drawing.Point(158, 109);
            this.Label2Password.Name = "Label2Password";
            this.Label2Password.Size = new System.Drawing.Size(124, 31);
            this.Label2Password.TabIndex = 3;
            this.Label2Password.Text = "Password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Green;
            this.buttonLogin.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(163, 208);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(134, 45);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLoginCancel
            // 
            this.buttonLoginCancel.BackColor = System.Drawing.Color.Red;
            this.buttonLoginCancel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginCancel.Location = new System.Drawing.Point(163, 400);
            this.buttonLoginCancel.Name = "buttonLoginCancel";
            this.buttonLoginCancel.Size = new System.Drawing.Size(135, 45);
            this.buttonLoginCancel.TabIndex = 5;
            this.buttonLoginCancel.Text = "Cancel";
            this.buttonLoginCancel.UseVisualStyleBackColor = false;
            this.buttonLoginCancel.Click += new System.EventHandler(this.buttonLoginCancel_Click);
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.BackColor = System.Drawing.Color.Yellow;
            this.buttonSignUp.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignUp.Location = new System.Drawing.Point(164, 322);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(134, 45);
            this.buttonSignUp.TabIndex = 6;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = false;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(126, 275);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(203, 22);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "Don\'t have account yet?";
            // 
            // linkLabelForgot
            // 
            this.linkLabelForgot.AutoSize = true;
            this.linkLabelForgot.LinkColor = System.Drawing.Color.Green;
            this.linkLabelForgot.Location = new System.Drawing.Point(306, 180);
            this.linkLabelForgot.Name = "linkLabelForgot";
            this.linkLabelForgot.Size = new System.Drawing.Size(121, 17);
            this.linkLabelForgot.TabIndex = 8;
            this.linkLabelForgot.TabStop = true;
            this.linkLabelForgot.Text = "Forgot password?";
            this.linkLabelForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForgot_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 472);
            this.Controls.Add(this.linkLabelForgot);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.buttonLoginCancel);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.Label2Password);
            this.Controls.Add(this.Label1Login);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Name = "LoginForm";
            this.Text = "Log in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label Label1Login;
        private System.Windows.Forms.Label Label2Password;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLoginCancel;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.LinkLabel linkLabelForgot;
    }
}

