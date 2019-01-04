using System;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Pillenpresse.Model;

namespace ppedv.Pillenpresse.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_db()
        {
            string conString = "Server=.;Database=PillenPresse_CreateTest;Trusted_Connection=true";
            using (var con = new EfContext(conString))
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();

                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_can_CRUD_Symptom()
        {
            string conString = "Server=.;Database=PillenPresse_test;Trusted_Connection=true";
            var sym = new Symptom() { Name = $"Husten_{Guid.NewGuid()}", ICD10 = "R04.2" };
            string newName = $"Bluthusten_{Guid.NewGuid()}";

            using (var con = new EfContext(conString))
            {
                //CREATE
                con.Symptome.Add(sym);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(sym.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }


            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                Assert.AreEqual(newName, loaded.Name);

                //DELETE
                con.Symptome.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                Assert.IsNull(loaded);
            }

        }


        [TestMethod]
        public void EfContext_can_CRUD_Symptom_fluent()
        {
            string conString = "Server=.;Database=PillenPresse_test;Trusted_Connection=true";
            var sym = new Symptom() { Name = $"Husten_{Guid.NewGuid()}", ICD10 = "R04.2" };
            string newName = $"Bluthusten_{Guid.NewGuid()}";

            using (var con = new EfContext(conString))
            {
                //CREATE
                con.Symptome.Add(sym);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                //Assert.IsNotNull(loaded);
                loaded.Should().NotBeNull();
                //Assert.AreEqual(sym.Name, loaded.Name);
                loaded.Name.Should().Be(sym.Name);

                loaded.Should().BeEquivalentTo(sym);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                //Assert.AreEqual(newName, loaded.Name);
                loaded.Name.Should().Be(newName);

                //DELETE
                con.Symptome.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                //Assert.IsNull(loaded);
                loaded.Should().BeNull();
            }

        }

        [TestMethod]
        public void EfContext_can_CreateRead_Symptom_fluent_autofix()
        {
            string conString = "Server=.;Database=PillenPresse_test;Trusted_Connection=true";
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            var sym = fix.Create<Symptom>();

            using (var con = new EfContext(conString))
            {
                //CREATE
                con.Symptome.Add(sym);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //READ
                var loaded = con.Symptome.Find(sym.Id);
                loaded.Should().BeEquivalentTo(sym, x =>
                {
                    x.IgnoringCyclicReferences();
                    x.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation)).WhenTypeIs<DateTime>();
                    return x;
                });
            }
        }
    }
}
