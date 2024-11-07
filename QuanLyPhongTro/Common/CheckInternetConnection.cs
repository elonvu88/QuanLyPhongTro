using System;
using System.Net;
using System.Windows.Forms;

namespace MyWork.Common
{
    public static class CheckInternetConnection
    {
        public static bool IsInternetConnected()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
