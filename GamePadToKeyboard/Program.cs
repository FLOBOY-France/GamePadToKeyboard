using OpenTK.Input;
using System;
using System.Configuration;

namespace GamePadToKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            ButtonState previousState = ButtonState.Released;
            DateTime dtLastPressed = DateTime.Now;
            int intervalleMS = int.Parse(ConfigurationManager.AppSettings["intervalleMS"]);
            string AppVersion = ConfigurationManager.AppSettings["AppVersion"];
            Console.WriteLine("_____________ GamePadToKeyboard v" + AppVersion + " _____________");
            Console.WriteLine("A : Activation, B : Clear, Back : Sortie de l'application");
            Console.WriteLine("Intervalle fixé à " + intervalleMS);

            int gamePadNumber = 0;
            
            for(int i=0; i<4; i++)
            {
              if (GamePad.GetState(i).IsConnected == true)
                {
                    gamePadNumber = i;
                    Console.WriteLine("Numero de pad : " + i);
                    break;
                }
            }

            while (true)
            {


                GamePadState state = GamePad.GetState(gamePadNumber);
                    if (state.Buttons.A.Equals(ButtonState.Released) && previousState.Equals(ButtonState.Pressed))
                    {

                        TimeSpan timeSpan = DateTime.Now - dtLastPressed;
                        if (timeSpan.TotalMilliseconds > intervalleMS)
                        {
                            dtLastPressed = DateTime.Now;
                            KeyboardSender.SendReturn();
                            //KeyboardSender.SendKey(0x0D);
                            Console.WriteLine("On a relâché A, écart : " + timeSpan.TotalMilliseconds);

                        }
                        else
                        {
                            Console.WriteLine("Non accepté : " + timeSpan.TotalMilliseconds + " < " + intervalleMS);
                        }
                    }

                    else if (state.Buttons.B.Equals(ButtonState.Pressed))
                        Console.Clear();
                    else if (state.Buttons.Back.Equals(ButtonState.Pressed))
                    {
                        Console.WriteLine("Êtes-vous sûr de vouloir sortir ? o/N");
                        string rep = Console.ReadLine();
                        if (rep.ToUpper().Equals("O"))
                            break;
                    }

                    previousState = state.Buttons.A;
                }
        }
    }
}

