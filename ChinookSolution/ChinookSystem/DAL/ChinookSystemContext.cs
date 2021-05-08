using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.Data.Entity;
using ChinookSystem.Entities;
#endregion

namespace ChinookSystem.DAL
{
    internal class ChinookSystemContext : DbContext
    {
        // we need a constructor as the connection string name 
        //  as an arguement value to entityFramework DbContext
        // We want to do this evertime we create an instance of this context classs

        public ChinookSystemContext()
            : base("name=ChinookDB")
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }


    }
}
