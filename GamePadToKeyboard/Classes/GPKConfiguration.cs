using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePadToKeyboard
{
    public enum EnvoiTouche { 
    kb_event,
    kb_press,
    kb_press_release,
    kb_release_press_release
    }

    public class GPKConfiguration
    {
        public EnvoiTouche envoiTouche {get;set;}

    }
}
