using ppedv.Pillenpresse.Model;
using ppedv.Pillenpresse.Model.Contracts;
using System;

namespace ppedv.Pillenpresse.Logic
{
    public class Core
    {
        public IDevice ActiveDevice { get; set; }
        public IRepository Repository { get; set; }

        public Core(IDevice device, IRepository repo)
        {
            ActiveDevice = device;
            Repository = repo;
        }


        public void MakeAllPills()
        {
            foreach (var item in Repository.GetAll<Symptom>())
            {
                MakePillsForSymptom(item);
            }
        }


        public void MakePillsForSymptom(Symptom sym)
        {
            if (sym == null)
                throw new ArgumentNullException();

            ActiveDevice.Machzeug(sym.Wirkstoffe);
        }
    }
}
