using Microsoft.EntityFrameworkCore;
using NewTreeTechApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewTreeTechApp.Data
{
    public class NewTreeTechContext : DbContext
    {
        public NewTreeTechContext(DbContextOptions<NewTreeTechContext> options) : base(options)
        {

        }

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Alarme> Alarmes { get; set; }
        public DbSet<AlarmeAtuado> AlarmesAtuados { get; set; }
    }
}
