using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandApi.Models;
using Optional;
using Optional.Collections;

namespace CommandApi.Repositories.Impl
{
    public class MockCommandApiRepository : ICommandApiRepository
    {
        private readonly List<Command> _commands;

        public MockCommandApiRepository()
        {
            this._commands = new List<Command>()
            {
                new Command()
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".NET Core EF"
                },
                new Command()
                {
                    Id = 1,
                    HowTo = "Run Migrations",
                    CommandLine = "dotnet ef database update",
                    Platform = ".NET Core EF"
                },
                new Command()
                {
                    Id = 2,
                    HowTo = "List active migrations",
                    CommandLine = "dotnet ef migrations list",
                    Platform = ".NET Core EF"
                }
            };
        }

        /// <inheritdoc />
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IEnumerable<Command> GetAllCommands()
        {
            return _commands;
        }

        /// <inheritdoc />
        public Option<Command> GetCommandById(int id)
        {
            return _commands.SingleOrNone(command => command.Id == id);
        }

        /// <inheritdoc />
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void DeleteCommand(int id)
        {
            throw new NotImplementedException();
        }
    }
}
