using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandApi.DataSource;
using CommandApi.Models;
using Microsoft;
using Microsoft.Extensions.DependencyInjection;
using Optional;
using Optional.Collections;


namespace CommandApi.Repositories.Impl
{
    public class SqlCommandApiRepository : ICommandApiRepository
    {
        private readonly CommandContext _context;

        public SqlCommandApiRepository(CommandContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public bool SaveChanges()
        {
            var affected = _context.SaveChanges();
            return affected > 0;
        }

        /// <inheritdoc />
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems;
        }

        /// <inheritdoc />
        public Option<Command> GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrNone(command => command.Id == id);
        }

        /// <inheritdoc />
        public void CreateCommand(Command cmd)
        {
            Requires.NotNull(cmd, nameof(cmd));
            _context.CommandItems.Add(cmd);
        }

        /// <inheritdoc />
        public void UpdateCommand(Command cmd)
        {
            // no need to implement UpdateCommand method.
        }

        /// <inheritdoc />
        public void DeleteCommand(int id)
        {

            throw new NotImplementedException();
        }
    }
}
