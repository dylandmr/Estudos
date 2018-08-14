using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemInicial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new TMContext())
            {
                contexto.SaveChanges();

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());
            }
        }

        private static void ImprimeChangeTracker(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("------------------------");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
            Console.WriteLine("------------------------");
        }
    }
}
