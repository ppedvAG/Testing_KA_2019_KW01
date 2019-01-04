using System.Collections.Generic;

namespace ppedv.Pillenpresse.Model
{
    public class Symptom : Entity
    {
        public string Name { get; set; }
        public string ICD10 { get; set; }
        public virtual HashSet<Wirkstoff> Wirkstoffe { get; set; } = new HashSet<Wirkstoff>();
    }
}
