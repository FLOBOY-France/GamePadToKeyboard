using WindowsInput;

namespace GamePadToKeyboard
{
    public class KeyboardSender
    {
        public static void SendReturn()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);

        }

    }
}
