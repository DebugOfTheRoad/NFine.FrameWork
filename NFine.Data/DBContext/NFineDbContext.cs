using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NFine.Data
{
    public class NFineDbContext : DbContext
    {
        public NFineDbContext() : base("NFineDbContext")
        {

        }
    }
}
