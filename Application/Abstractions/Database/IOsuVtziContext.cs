using Application.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Database;

public interface IOsuVtziContext
{
    public DbSet<AdminEntity> Admin { get; set; }
}