using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinExample.Controllers.AccountController.Structures
{
    public class IoC
    {
        public static IUnityContainer Instance
        {
            get { return m_UnityContainer ?? (m_UnityContainer = new UnityContainer()); }
        }

        private static IUnityContainer m_UnityContainer;
    }
}
