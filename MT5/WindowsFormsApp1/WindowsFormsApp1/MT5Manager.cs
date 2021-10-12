//+------------------------------------------------------------------+
//|                                MetaTrader 5 API Manager for .NET |
//|                        Copyright 2012-2021, OBI HOLDINGS PTE LTD |
//|                                              https://obih.sg/ja/ |
//+------------------------------------------------------------------+
namespace MT5Manager
{
    using MetaQuotes.MT5CommonAPI;
    using MetaQuotes.MT5ManagerAPI;
    using System;

    //+------------------------------------------------------------------+
    //| Manager                                                          |
    //+------------------------------------------------------------------+
    public class CManager : IDisposable
    {
        //--- connect timeout in milliseconds
        uint MT5_CONNECT_TIMEOUT = 30000;
        //---
        CIMTManagerAPI m_manager = null;
        CIMTDealArray m_deal_array = null;
        CIMTUser m_user = null;
        CIMTUserArray m_users = null;
        CIMTAccount m_account = null;
        //+------------------------------------------------------------------+
        //| Constructor                                                      |
        //+------------------------------------------------------------------+
        public CManager()
        {
        }
        //+------------------------------------------------------------------+
        //| Destructor                                                       |
        //+------------------------------------------------------------------+
        public void Dispose()
        {
            Shutdown();
        }
        //+------------------------------------------------------------------+
        //| Initialize library                                               |
        //+------------------------------------------------------------------+
        public bool Initialize()
        {
            string message = string.Empty;
            MTRetCode res = MTRetCode.MT_RET_OK_NONE;
            //--- loading manager API
            if ((res = SMTManagerAPIFactory.Initialize(null)) != MTRetCode.MT_RET_OK)
            {
                message = string.Format("Loading manager API failed ({0})", res);
                System.Console.WriteLine(message);
                return (false);
            }
            //--- creating manager interface
            m_manager = SMTManagerAPIFactory.CreateManager(SMTManagerAPIFactory.ManagerAPIVersion, out res);
            if ((res != MTRetCode.MT_RET_OK) || (m_manager == null))
            {
                SMTManagerAPIFactory.Shutdown();
                message = string.Format("Creating manager interface failed ({0})", (res == MTRetCode.MT_RET_OK ? "Managed API is null" : res.ToString()));
                System.Console.WriteLine(message);
                return (false);
            }
            //--- create deal array
            if ((m_deal_array = m_manager.DealCreateArray()) == null)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "DealCreateArray fail");
                System.Console.WriteLine("DealCreateArray fail");
                return (false);
            }
            //--- create user interface
            if ((m_user = m_manager.UserCreate()) == null)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserCreate fail");
                System.Console.WriteLine("UserCreate fail");
                return (false);
            }
            //--- create user array interface
            if ((m_users = m_manager.UserCreateArray()) == null)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserCreateArray fail");
                System.Console.WriteLine("UserCreateArray fail");
                return (false);
            }
            //--- create account interface
            if ((m_account = m_manager.UserCreateAccount()) == null)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserCreateAccount fail");
                System.Console.WriteLine("UserCreateAccount fail");
                return (false);
            }
            //--- all right
            return (true);
        }
        //+------------------------------------------------------------------+
        //| Login                                                            |
        //+------------------------------------------------------------------+
        public bool Login(string server, UInt64 login, string password)
        {
            //--- connect
            MTRetCode res = m_manager.Connect(server, login, password, null, CIMTManagerAPI.EnPumpModes.PUMP_MODE_FULL, MT5_CONNECT_TIMEOUT);
            if (res != MTRetCode.MT_RET_OK)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "Connection failed ({0})", res);
                return (false);
            }
            return (true);
        }
        //+------------------------------------------------------------------+
        //| Logout                                                           |
        //+------------------------------------------------------------------+
        public void Logout()
        {
            //--- disconnect manager
            if (m_manager != null)
                m_manager.Disconnect();
        }
        //+------------------------------------------------------------------+
        //| Shutdown                                                         |
        //+------------------------------------------------------------------+
        public void Shutdown()
        {
            if (m_deal_array != null)
            {
                m_deal_array.Dispose();
                m_deal_array = null;
            }
            if (m_manager != null)
            {
                m_manager.Dispose();
                m_manager = null;
            }
            if (m_user != null)
            {
                m_user.Dispose();
                m_user = null;
            }
            if (m_users != null)
            {
                m_users.Dispose();
                m_users = null;
            }
            if (m_account != null)
            {
                m_account.Dispose();
                m_account = null;
            }
            SMTManagerAPIFactory.Shutdown();
        }
        //+------------------------------------------------------------------+
        //| Get array of dealer balance operation                            |
        //+------------------------------------------------------------------+
        public bool GetUserDeal(out CIMTDealArray deals, UInt64 login, DateTime time_from, DateTime time_to)
        {
            deals = null;
            //--- request array
            MTRetCode res = m_manager.DealRequest(login, SMTTime.FromDateTime(time_from), SMTTime.FromDateTime(time_to), m_deal_array);
            if (res != MTRetCode.MT_RET_OK)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "DealRequest fail({0})", res);
                return (false);
            }
            //---
            deals = m_deal_array;
            return (true);
        }
        //+------------------------------------------------------------------+
        //| Get user info string                                             |
        //+------------------------------------------------------------------+
        public CIMTUser GetUserInfo(UInt64 login)
        {
            //--- request user from server
            m_user.Clear();
            MTRetCode res = m_manager.UserRequest(login, m_user);
            if (res != MTRetCode.MT_RET_OK)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserRequest error ({0})", res);
                return (null);
            }
            //---
            return (m_user);
        }
        //+------------------------------------------------------------------+
        //| Get user info string                                             |
        //+------------------------------------------------------------------+
        public CIMTAccount GetAccountInfo(UInt64 login)
        {
            m_account.Clear();
            MTRetCode res = m_manager.UserAccountRequest(login, m_account);
            if (res != MTRetCode.MT_RET_OK)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserAccountRequest error ({0})", res);
                return (null);
            }
            //---
            return (m_account);
        }
        //+------------------------------------------------------------------+
        //| Dealer operation                                                 |
        //+------------------------------------------------------------------+
        public bool DealerBalance(UInt64 login, double amount, uint type, string comment, bool deposit)
        {
            ulong deal_id;
            MTRetCode res = m_manager.DealerBalance(login, deposit ? amount : -amount, type, comment, out deal_id);
            if (res != MTRetCode.MT_RET_REQUEST_DONE)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "DealerBalance error ({0})", res);
                return (false);
            }
            return (true);
        }
        //+------------------------------------------------------------------+
        //| Get User Array                                                   |
        //+------------------------------------------------------------------+
        // https://support.metaquotes.net/en/docs/mt5/api/imtmanagerapi/imtmanagerapi_user/imtmanagerapi_userrequestarray
        public CIMTUserArray GetUsers(string group)
        {
            m_users.Clear();
            MTRetCode res = m_manager.UserRequestArray(group, m_users);
            if (res != MTRetCode.MT_RET_OK)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserRequestArray error ({0})", res);
                return (null); ;
            }
            return (m_users);
        }
        //+------------------------------------------------------------------+
        //| Get User Array                                                   |
        //+------------------------------------------------------------------+
        public bool GetGroup(ulong login, out string group)
        {
            MTRetCode res = m_manager.UserGroup(login, out group);
            if (res != MTRetCode.MT_RET_OK)
            {
                m_manager.LoggerOut(EnMTLogCode.MTLogErr, "UserGroup error ({0})", res);
                return (false);
            }
            return (true);
        }
    }
}