using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamePadToKeyboard
{
    public class KeyboardSender
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

        private const int VK_Return = 0x0D; //Constante pour la touche Return

        public static void SendReturn()
        {
            keybd_event(VK_Return, 0, 0, 0);
        }

        public static void SendKey(uint keyCode)
        {
            keybd_event(keyCode, 0, 0, 0); //Simuler autre touche, liste disponible ici : http://www.kbdedit.com/manual/low_level_vk_list.html
        }

    }
}
