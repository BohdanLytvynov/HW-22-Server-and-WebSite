using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security;

namespace HW21_MVC.Models
{
    public class User
    {
        private string m_login;

        private int[] m_pass;

        public string Login { get => m_login; set => m_login = value; }

        public int[] Pass { get => m_pass; set => m_pass = value; }
    }
}
