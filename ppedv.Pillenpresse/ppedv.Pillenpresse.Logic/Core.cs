using ppedv.Pillenpresse.Model;
using ppedv.Pillenpresse.Model.Contracts;
using System;

namespace ppedv.Pillenpresse.Logic
{
    public class Core
    {
        public IDevice ActiveDevice { get; set; }

        public Core(IDevice device)
        {
            ActiveDevice = device;
        }


        public void MakePillsForSymptom(Symptom sym)
        {
            if (sym == null)
                throw new ArgumentNullException();

            ActiveDevice.Machzeug(sym.Wirkstoffe);  
        }
    }
}
