using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes.Actions
{
    public static class Talk
    {
        public static bool TalkToNurse()
        {
            InputHandler.SendKeys(new string[] { "hi" }, 200);
            return true;
        }
    }
}
