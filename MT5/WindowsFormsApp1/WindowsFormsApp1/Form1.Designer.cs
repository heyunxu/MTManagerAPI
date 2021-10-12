namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUserLogin = new System.Windows.Forms.TextBox();
            this.btnGetUser = new System.Windows.Forms.Button();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.lblUserLogin = new System.Windows.Forms.Label();
            this.grpAdmin = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.grpAdmin.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.Location = new System.Drawing.Point(168, 48);
            this.txtUserLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Size = new System.Drawing.Size(225, 31);
            this.txtUserLogin.TabIndex = 1;
            // 
            // btnGetUser
            // 
            this.btnGetUser.Location = new System.Drawing.Point(403, 48);
            this.btnGetUser.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnGetUser.Name = "btnGetUser";
            this.btnGetUser.Size = new System.Drawing.Size(195, 31);
            this.btnGetUser.TabIndex = 2;
            this.btnGetUser.Text = "ユーザー情報取得";
            this.btnGetUser.UseVisualStyleBackColor = true;
            this.btnGetUser.Click += new System.EventHandler(this.btnGetUser_Click);
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Location = new System.Drawing.Point(403, 130);
            this.btnGetUsers.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(195, 68);
            this.btnGetUsers.TabIndex = 5;
            this.btnGetUsers.Text = "グループに所属する\r\nユーザーを取得";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.btnGetUsers_Click);
            // 
            // lblUserLogin
            // 
            this.lblUserLogin.AutoSize = true;
            this.lblUserLogin.Location = new System.Drawing.Point(46, 51);
            this.lblUserLogin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUserLogin.Name = "lblUserLogin";
            this.lblUserLogin.Size = new System.Drawing.Size(74, 24);
            this.lblUserLogin.TabIndex = 0;
            this.lblUserLogin.Text = "ログイン";
            // 
            // grpAdmin
            // 
            this.grpAdmin.Controls.Add(this.lblPassword);
            this.grpAdmin.Controls.Add(this.txtPassword);
            this.grpAdmin.Controls.Add(this.lblLogin);
            this.grpAdmin.Controls.Add(this.txtLogin);
            this.grpAdmin.Controls.Add(this.lblServer);
            this.grpAdmin.Controls.Add(this.txtServer);
            this.grpAdmin.Controls.Add(this.btnLogin);
            this.grpAdmin.Location = new System.Drawing.Point(12, 12);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(640, 188);
            this.grpAdmin.TabIndex = 0;
            this.grpAdmin.TabStop = false;
            this.grpAdmin.Text = "管理者ログイン情報";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(46, 137);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 24);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "パスワード";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(168, 134);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(225, 31);
            this.txtPassword.TabIndex = 6;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(46, 94);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(74, 24);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "ログイン";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(168, 91);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(225, 31);
            this.txtLogin.TabIndex = 4;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(46, 51);
            this.lblServer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(74, 24);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "サーバー";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(168, 48);
            this.txtServer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(225, 31);
            this.txtServer.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(403, 48);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(195, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ログイン";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.lblGroup);
            this.grpUser.Controls.Add(this.txtGroup);
            this.grpUser.Controls.Add(this.btnGetUsers);
            this.grpUser.Controls.Add(this.txtUserLogin);
            this.grpUser.Controls.Add(this.btnGetUser);
            this.grpUser.Controls.Add(this.lblUserLogin);
            this.grpUser.Location = new System.Drawing.Point(12, 215);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(640, 217);
            this.grpUser.TabIndex = 1;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "ユーザー情報";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(46, 94);
            this.lblGroup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(74, 24);
            this.lblGroup.TabIndex = 3;
            this.lblGroup.Text = "グループ";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(168, 91);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(225, 31);
            this.txtGroup.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 441);
            this.Controls.Add(this.grpUser);
            this.Controls.Add(this.grpAdmin);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Validated += new System.EventHandler(this.Form1_Validated);
            this.grpAdmin.ResumeLayout(false);
            this.grpAdmin.PerformLayout();
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserLogin;
        private System.Windows.Forms.Button btnGetUser;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.Label lblUserLogin;
        private System.Windows.Forms.GroupBox grpAdmin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtGroup;
    }
}

