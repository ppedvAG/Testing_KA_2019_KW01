using System;

namespace ACME.PillPress
{
    public class PillPresser
    {
        bool init = false;
        public void Init()
        {
            init = true;
        }

        public void CreatePill(string pillConfig)
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
        }
    }
}
