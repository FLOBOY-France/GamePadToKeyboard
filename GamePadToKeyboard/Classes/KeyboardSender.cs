using System;
using System.Runtime.InteropServices;

namespace GamePadToKeyboard
{
    public class KeyboardSender
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

        private const int VK_Return = 0x0D; //Constante pour la touche Return

        public const ushort WM_KEYDOWN = 0x0100;

        public const ushort WM_KEYUP = 0x0101;

        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();


        [DllImport("user32.dll")] //sends a windows message to the specified window
        public static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, int lParam);


        public static void SendReturn()
        {
            keybd_event(VK_Return, 0, 0, 0);
        }

        public static void SendKey(uint keyCode)
        {
            //keybd_event(keyCode, 0, 0, 0); //Simuler autre touche, liste disponible ici : http://www.kbdedit.com/manual/low_level_vk_list.html
            SendMessage(GetActiveWindow(), WM_KEYUP, VK_Return, 0);
            SendMessage(GetActiveWindow(), WM_KEYDOWN, VK_Return, 0);
            SendMessage(GetActiveWindow(), WM_KEYUP, VK_Return, 0);
        }

    }
}
