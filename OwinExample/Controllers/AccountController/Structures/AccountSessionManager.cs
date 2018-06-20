using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using OwinExample.Controllers;

namespace OwinExample.Controllers.AccountController.Structures
{
    public interface IAccountSessions
    {
        AuthData GetAuthData(string guid);

        bool ContainsSession(string guid);
    }

    public interface IAccountSessionManager : IAccountSessions
    {
        void AddSession(string guid, AuthData data);
        void RemoveSession(string guid);        
    }

    public class AccountSessionManager : IAccountSessionManager
    {
        public AccountSessionManager()
        {
            m_Sessions = new Dictionary<string, AuthData>();
        }

        public bool ContainsSession(string guid)
        {
            return m_Sessions.ContainsKey(guid);
        }

        public AuthData GetAuthData(string guid)
        {
            if (ContainsSession(guid))
                return m_Sessions[guid];

            return null;
        }

        public void AddSession(string guid, AuthData data)
        {
            m_Sessions.Add(guid, data);
        }

        public void RemoveSession(string guid)
        {
            m_Sessions.Remove(guid);
        }

        private readonly Dictionary<string, AuthData> m_Sessions;
    }
}