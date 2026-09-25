using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) {}

    public DbSet<Card> Cards { get; set; }
}