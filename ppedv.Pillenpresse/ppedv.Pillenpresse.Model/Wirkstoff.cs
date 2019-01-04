using System.Collections.Generic;

namespace ppedv.Pillenpresse.Model
{
    public class Wirkstoff : Entity
    {
        public string Name { get; set; }
        public double MengeProEinheit { get; set; }
        public virtual HashSet<Symptom> Symptome { get; set; } = new HashSet<Symptom>();
    }
}
