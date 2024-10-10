using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldLibrary
{
    public class GreetingService
    {
        public string GetGreeting(string username)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return $"{currentTime} Hello, {username}";
        }
    }
}
