using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    class LoginViewModel
    {
        public async Task Login(string mail, string pw)
        {
            HttpClient client = new HttpClient();
        }
    }
}
