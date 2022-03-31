using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SnackbarAPI.Data.Entities;

namespace SnackbarAPI.Data
{
    public class SnackbarDbContext : DbContext
    {
        public SnackbarDbContext (DbContextOptions<SnackbarDbContext> options)
            : base(options)
        {
        }

        public DbSet<SnackbarAPI.Data.Entities.Snack> Snacks { get; set; }
    }
}
