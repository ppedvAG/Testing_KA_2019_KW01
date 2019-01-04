using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.Pillenpresse.Model.Contracts
{
    public interface IDevice
    {
        void Machzeug(IEnumerable<Wirkstoff> wirkstoffe);
        void Machzeug(Func<IEnumerable<Wirkstoff>> isAny);
    }
}
