using System;
using System.Collections.Generic;
using System.Windows.Forms;
using P23.MetaTrader4.Manager;
using P23.MetaTrader4.Manager.Contracts;
using System.Diagnostics;

// https://github.com/tamdestek/MetaTrader4.Manager.Wrapper
namespace WindowsFormsApp1
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// MT4 Manager Wrapper クラスをインスタンス化します。
        /// </summary>
        ClrWrapper metatrader = new ClrWrapper();

        /// <summary>
        /// デフォルト コンストラクタです。
        /// コンポーネントの初期化を行います。
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームが破棄されたときに実行されるイベントです。
        /// MT4 Manager Wrapper クラスから切断し、インスタンスを破棄します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Validated(object sender, EventArgs e)
        {
            // 管理者ログイン中の状態から切断します
            metatrader.Disconnect();

            // MT4 Manager Wrapper クラスのインスタンスを破棄します
            metatrader.Dispose();
        }

        /// <summary>
        /// 管理者ログインボタンのクリックイベントです。
        /// 入力されている管理者情報でログインを試みます。
        /// ログインに成功した場合はログイン状態を継続し、ログインに失敗した場合はエラーメッセージを表示します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 接続に必要となるパラメータのインスタンスを生成します
            ConnectionParameters parameters = new ConnectionParameters();

            // フォームに入力されている接続情報をパラメータにセットします
            parameters.Server = txtServer.Text;
            parameters.Login = int.Parse(txtLogin.Text);
            parameters.Password = txtPassword.Text;

            // 管理者ログインに接続を試みます
            try
            {
                metatrader = new ClrWrapper(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("接続失敗..." + ex.Message);
                return;
            }

            MessageBox.Show("接続成功！");
        }

        /// <summary>
        /// 「すべてのユーザーを取得」ボタンのクリックイベントです。
        /// すべてのユーザーが取得されるため、非常に時間がかかります。
        /// データが取得されているかどうかの確認は、users配列のなかをウォッチ式で参照することをお勧めします
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            // 1人ずつのユーザー情報を格納するUserRecordのリスト型を定義します
            IList<UserRecord> users = metatrader.UsersRequest();

            // データを取得する例です
            for (int i = 0; i <= users.Count - 1; ++i)
            {
                // ※
                // データ件数が多すぎて、すべてを出力できません
                Debug.WriteLine(users[i].Name);
            }
        }
    }
}
