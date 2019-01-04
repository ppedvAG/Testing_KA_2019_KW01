using Binford.PillenPunisher5000;
using ppedv.Pillenpresse.Model;
using System.Collections.Generic;

namespace ppedv.Pillenpresse.Device.Binford
{
    public class BinfordManager
    {
        public void CreatePill(IEnumerable<Wirkstoff> wirkstoffe)
        {
            PillenPunisher.MakePill(300, null);
        }
    }
}
