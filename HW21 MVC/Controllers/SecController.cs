using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW21_MVC.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using System.Threading;

namespace HW21_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SecController : Controller
    {
        private object m_sync;

        private UserManager<IdentityUser> m_userManager;

        private SignInManager<IdentityUser> m_signInManager;

        private static Dictionary<string, List<bool>> m_userCheckResultdictionary;

        static SecController()
        {
            m_userCheckResultdictionary = new Dictionary<string, List<bool>>();
            ///List<bool> (0 - IsFound, 1 - IsAuthorCorrect 2 - IsAdmin)
        }

        public SecController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            m_userManager = userManager;

            m_signInManager = signInManager;

            m_sync = new object();
        }

        [HttpPost]
        public async void UserValidation([FromBody] User user)
        {
            IdentityUser UserSearchResult = m_userManager.FindByNameAsync(user.Login).Result;

            if (UserSearchResult == null)
            {
                if (!m_userCheckResultdictionary.ContainsKey(user.Login))

                    m_userCheckResultdictionary.Add(
                    user.Login, new List<bool> { false, false, false });

                return;
            }

            await m_signInManager.SignOutAsync();

            Microsoft.AspNetCore.Identity.SignInResult SignResult =
                await m_signInManager.CheckPasswordSignInAsync(UserSearchResult,
               GetPassword(user.Pass), false);

            await m_signInManager.SignOutAsync();

            if (SignResult.Succeeded)
            {
                if (m_userManager.IsInRoleAsync(UserSearchResult, "admin").Result)//Is Admin
                {
                    if(!m_userCheckResultdictionary.ContainsKey(user.Login))
                        m_userCheckResultdictionary.Add(
                        user.Login, new List<bool> { true, true, true });

                    return;
                }
                else //is User
                {
                    if(!m_userCheckResultdictionary.ContainsKey(user.Login))                        
                        m_userCheckResultdictionary.Add(
                        user.Login, new List<bool> { true, true, false });
                                        
                    return;

                }
            }

            m_userCheckResultdictionary.Add(
                user.Login, new List<bool> { true, false, false });

        }

        [HttpGet]
        [Route("GetAuthResponse/{login}")]
        public async Task<List<bool>> GetAuthorizationResult(string login)
        {
            List<bool> result = null;

            string str = login.Trim('{', '}');

            await Task.Run(() =>
            {
                m_userCheckResultdictionary.TryGetValue(str, out result);

                Monitor.Enter(m_sync);

                m_userCheckResultdictionary.Remove(str);

                Monitor.Exit(m_sync);
            });

            return result;
        }

        private string GetPassword(int[] secStr)
        {
            if (secStr == null)
            {
                return String.Empty;
            }
            StringBuilder sb = new StringBuilder(secStr.Length);
            for (int i = 0; i < secStr.Length; i++)
            {
                sb.Append((char)secStr[i]);
            }

            return sb.ToString();
        }
    }
}
