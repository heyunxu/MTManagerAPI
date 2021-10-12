using System;
using System.Windows.Forms;
using MetaQuotes.MT5CommonAPI;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        MT5Manager.CManager cManager = new MT5Manager.CManager();

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // MT5Manager を初期化
            if (cManager.Initialize() == false)
            {
                MessageBox.Show("Initialize Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Validated(object sender, EventArgs e)
        {
            // MT5Manager 内のインスタンスを解放
            cManager.Shutdown();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 管理者ログイン情報に入力された値を取得
            string server = txtServer.Text;
            ulong login = ulong.Parse(txtLogin.Text);
            string password = txtPassword.Text;

            if (cManager.Login(server, login, password) == false)
            {
                MessageBox.Show("ログイン情報が正しくありません。");
                return;
            }

            MessageBox.Show("ログイン成功！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUser_Click(object sender, EventArgs e)
        {
            UInt64 login = UInt64.Parse(txtUserLogin.Text);

            // ユーザー情報を取得
            CIMTUser user = cManager.GetUserInfo(login);

            // アカウント情報を取得
            CIMTAccount acc = cManager.GetAccountInfo(login);

            // ※
            // 上記の取得した内容を出力する処理は入れていませんが、クラスのなかに入っているのを確認できます
            txtGroup.Text = user.Group();       // プロパティではなく、メソッドで該当値を取得するようなので注意！
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            string group = txtGroup.Text;

            CIMTUserArray users = cManager.GetUsers(group);

            // 使い方の例
            string userNames = "";
            for (uint i = 0; i <= users.Total() - 1; ++i)
            {
                CIMTUser user = users.Next(i);
                string userName = user.Name();
                userNames += userName;
            }

            MessageBox.Show(userNames);
        }
    }
}
