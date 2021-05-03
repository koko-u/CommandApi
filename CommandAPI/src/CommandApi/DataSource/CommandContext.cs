using CommandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandApi.DataSource
{
    public class CommandContext : DbContext
    {
        /// <inheritdoc />
        public CommandContext(DbContextOptions<CommandContext> options)
            : base(options) {}

        public DbSet<Command> CommandItems { get; set; }
    }
}
