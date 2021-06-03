using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenTK.Input;

namespace GamePadToKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            ButtonState previousState = ButtonState.Released;
            DateTime dtLastPressed = DateTime.Now;
            int intervalleMS = int.Parse(ConfigurationManager.AppSettings["intervalleMS"]);

            Console.WriteLine("A : Activation, B : Clear, Back : Sortie de l'application");
            Console.WriteLine("Intervalle fixé à " + intervalleMS);

            while (true)
            {
                GamePadState state = GamePad.GetState(0);


                if (state.Buttons.A.Equals(ButtonState.Released) && previousState.Equals(ButtonState.Pressed))
                {

                    TimeSpan timeSpan = DateTime.Now - dtLastPressed;
                    if (timeSpan.TotalMilliseconds > intervalleMS)
                    {
                        dtLastPressed = DateTime.Now;
                        KeyboardSender.SendReturn();
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
}
