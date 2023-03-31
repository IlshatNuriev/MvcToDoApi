using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcToDoApi.Models;

namespace MvcToDoApi.Data
{
    public class MvcToDoApiContext : DbContext
    {
        public MvcToDoApiContext (DbContextOptions<MvcToDoApiContext> options)
            : base(options)
        {
        }

        public DbSet<MvcToDoApi.Models.ProjectItem> ProjectItem { get; set; } = default!;
    }
}
