using PxgBot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PxgBot.Classes
{
    public static class Alarms
    {
        public static bool FindGlobalMessage()
        {
            if (GUI.ChatRect.IsEmpty == false)
            {
                int[] yellowPixel = ImageHandler.UseImageSearch("Screen\\yellowPixel.png", GUI.ChatRect.X, GUI.ChatRect.Y, GUI.ChatRect.Width);
                if (yellowPixel != null)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public static bool FindPrivateMessage()
        {
            if (GUI.ChatRect.IsEmpty == false)
            {
                int[] yellowPixel = ImageHandler.UseImageSearch("Screen\\bluePixel.png", GUI.ChatRect.X, GUI.ChatRect.Y, GUI.ChatRect.Width);
                if (yellowPixel != null)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
