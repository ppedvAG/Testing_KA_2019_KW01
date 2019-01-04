using ppedv.Pillenpresse.Model;
using System.Data.Entity;

namespace ppedv.Pillenpresse.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Wirkstoff> Wirkstoffe { get; set; }
        public DbSet<Symptom> Symptome { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=.;Database=PillenPresse_test;Trusted_Connection=true")
        { }
    }
}
