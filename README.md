# MT Manager APIを利用したC#サンプルコード（MT4・MT5）

ここで紹介しているアプリは、MetaQuotes社のMT Manager APIの使い方を理解するためのアプリです。

MT Manager APIは、トレーダーのためのAPIではなく、ブローカーのためのAPIです。

そのため、トレーダーがMetaTraderにログインする際のサーバー名、ログイン、パスワードでは本アプリを使うことはできません。

ご注意ください。

## MT4
MT4のManager APIは、ネイティブDLLとしてMetaQuotes社から提供されているため、C#から呼び出す際は、DLLImportsを利用する必要があります。

しかし、GitHubに公開されていた、以下の.NETライブラリを利用することで、このネイティブDLLを.NETでかんたんに利用することが可能となります。

https://github.com/tamdestek/MetaTrader4.Manager.Wrapper

## MT5
MT5のManager APIは、ネイティブDLLと.NET DLLの2種類がMetaQuotes社から提供されています。

.NET DLLは、ネイティブDLLのWrapperクラスのようです。

この.NET DLLは、GitHubにアップされていた、以下のものを利用させていただきました。

https://github.com/sfissw

## ユーザー情報の取得について

このアプリは、管理者ログインの方法と、ユーザー情報の取得の方法をロジック化しています。

ユーザー情報の取得は、MT4とMT5とで違います。

### MT4
MT4では、UsersRequest()メソッドを実行することで、すべてのユーザーのユーザー情報を取得することができます。

### MT5
MT5では、UserRequest()メソッドで、指定したユーザーのログインIDのユーザー情報を取得することができます。

また、UserRequestArray()メソッドで、指定したグループに所属する複数のユーザーのユーザー情報を取得することができます。

## MT4・MT5各々のメリットとデメリット
MT4の場合、管理者のログイン情報さえわかれば、すべてのユーザーの情報を取得することができるが、MT5の場合、取得したいユーザーのグループ名が必要となります。

一見、MT4の方が便利な気がしますが、非常に大量のデータが取得されるため、すべてのデータを取得するまでにそれなりに時間がかかります。

MT5の場合、グループ名がわからないと、複数のユーザーを取得することができませんが、幸い、UserRequest()メソッドによって1人のユーザーが所属するグループ名を取得することもできるため、「グループ名の正式名はわからないけど、そのグループにはこのログインIDを持つユーザーがいることだけはわかっている」といったケースでには使えそうです。

ただ正直、MT5のAPIの方が、使いづらい感じです。

## 各々の使い方について

### MT4 Manager APIについて
MT4 Manager APIの本体は、次の2つのDLLで構成されています。

* mtmanapi.dll
* mtmanapi64.dll

C++で開発されたネイティブDLLであるため、C#からこれらのDLLを呼び出す際は、DLLImportsでDLLを宣言する必要があります。

ちなみに、MT4のEAからDLLを呼び出す場合も同様です。

しかし、DLLImportsでDLLを宣言するタイプのものは、インテリセンスが効かないため、予め利用するメンバの仕様を調査しておく必要があり、大変面倒です。

そこで、上述のとおり、MT4 Manager APIのDLLを.NETから利用するためのWrapperクラスを使います。

このWrapperクラスを使うことにより、.NETライブラリとそん色なく（インテリセンスの機能も使える）、MT4 Manager APIを利用することができます。

C#で開発する場合におけるC++の開発効率の悪さを考慮すると、C#で開発した方が、かなり開発コストを下げることが可能と思われますし、C++開発者よりもC#開発者の方が人口が多いため、このWrapperクラスは大変有用です。

上記GitHubに公開されていたWrapperクラスは、ビルドすることにより、以下の2つの.NET DLLが生成されます。

* P23.MetaTrader4.Manager.Contracts.dll
* P23.MetaTrader4.Manager.ClrWrapper.dll

このDLLをMetaQuotes社から提供されている上記2つのネイティブDLLと同じフォルダに配置し、アプリからはこのDLLの参照設定のみを行います。

（ネイティブDLLは.NETから参照設定できません）

参照設定が完了したら、まずはこのDLLを使うモジュール内にて、次のように名前空間の登録を行います。

    using P23.MetaTrader4.Manager;
    using P23.MetaTrader4.Manager.Contracts;

続いて、次のような記述により、管理者ログインに接続するために必要なクラスをインスタンス化します。

    /// <summary>
    /// MT4 Manager Wrapper クラスをインスタンス化します。
    /// </summary>
    ClrWrapper metatrader = new ClrWrapper();

管理者ログインのためには、「サーバー名」「ログインID」「パスワード」が必要となりますが、これらのパラメータは、次のような記述で、上記のWrapperクラスのインスタンスにセットします。

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

接続がうまくいった場合は、このインスタンスのUsersRange()メソッドをパラメータなしで実行することで、すべてのユーザー情報の配列を取得することが可能です。

    // 1人ずつのユーザー情報を格納するUserRecordのリスト型を定義します
    IList<UserRecord> users = metatrader.UsersRequest();

    // データを取得する例です
    for (int i = 0; i <= users.Count - 1; ++i)
    {
        // ※
        // データ件数が多すぎて、すべてを出力できません
        Debug.WriteLine(users[i].Name);
    }

最後に、管理者ログイン状態から切断し、MT4 Manager Wrapperクラスを解放する。

    // 管理者ログイン中の状態から切断します
    metatrader.Disconnect();

    // MT4 Manager Wrapper クラスのインスタンスを破棄します
    metatrader.Dispose();


### MT5 Manager APIについて

MT5 Manager APIは、これらのファイルがMetaQuotes社から提供されています。

* MetaQuotes.MT5CommonAPI.dll
* MetaQuotes.MT5CommonAPI64.dll
* MetaQuotes.MT5GatewayAPI.dll
* MetaQuotes.MT5GatewayAPI64.dll
* MetaQuotes.MT5ManagerAPI.dll
* MetaQuotes.MT5ManagerAPI64.dll
* MetaQuotes.MT5WebAPI.dll
* MT5APIGateway.dll
* MT5APIGateway64.dll
* MT5APIManager.dll
* MT5APIManager64.dll

このうち、ファイル名の末尾に「64」が付いているものが64ビット専用、付いていないものが「32」ビット専用です。

また、ファイル名の先頭に「MetaQuotes.」が付いているものが、.NETライブラリです。

「MetaQuotes.」付きの.NETライブラリは、「MetaQuotes.」付きでないネイティブライブラリのWrapperクラスと思われ、.NET側から参照設定していなくても、同一フォルダ内に存在していることが必須です。

そのため、常にこれらのファイルはワンセットで扱います。

これらのDLLを利用したアプリを.NETで開発する場合、該当プロジェクトより、「MetaQuotes.」のDLLを参照設定する必要があります。

MT4 Manager Wrapperクラスと違い、おそらくMT5のネイティブDLLからの仕様と思われるが、正直、複数のクラスが絡み合っており、若干使いづらくてわかりにくいです。

以下のGitHubのサイトにて、MT5 Manager APIを使いやすくするためのモジュールが入手できたので、これを流用して開発しています。

* MT5Manager.cs

このモジュールの使い方は、次のとおりです。

まず、名前空間に以下の一文を追加します。

    using MetaQuotes.MT5CommonAPI;

管理者ログインを実装するためには、以下のクラスをインスタンス化します。

    /// <summary>
    /// 
    /// </summary>
    MT5Manager.CManager cManager = new MT5Manager.CManager();

インスタンス化した後、Initialize()メソッドを実行することで、MT5 Manager APIを使うために必要な関連クラスの初期化が実行されます。

    // MT5Manager を初期化
    if (cManager.Initialize() == false)
    {
        MessageBox.Show("Initialize Error");
    }

管理者ログインは、Loginメソッドにて、「サーバー名」「ログインID」「パスワード」を指定して実行します。

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

管理者ログインに成功すると、次のような方法で、指定したユーザー1人のユーザー情報を取得することができます。

    UInt64 login = UInt64.Parse(txtUserLogin.Text);

    // ユーザー情報を取得
    CIMTUser user = cManager.GetUserInfo(login);

    // アカウント情報を取得
    CIMTAccount acc = cManager.GetAccountInfo(login);

    // ※
    // 上記の取得した内容を出力する処理は入れていませんが、クラスのなかに入っているのを確認できます
    txtGroup.Text = user.Group();       // プロパティではなく、メソッドで該当値を取得するようなので注意！

複数のユーザーのユーザー情報を取得する場合は、取得したいユーザーが所属するグループ名を指定します。

ここがMT4と違うところで、逆にいえば、グループ名がわからないと、ユーザー情報を取得することができないようです。

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

また、ちょっとわかりづらかったのが、ユーザーの名前や住所を入手するのが、NameやAddressなどのメソッドとなっており、プロパティではありません。

そのため、

    user.Name;

ではなく、

    user.Name();

と記述します。

最後に、MT5Managerでインスタンス化されている各種クラスを破棄するには、Shutdown()メソッドを実行します。

    // MT5Manager 内のインスタンスを解放
    cManager.Shutdown();
