using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandApi.Models;
using Optional;

namespace CommandApi.Repositories
{
    public interface ICommandApiRepository
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();

        Option<Command> GetCommandById(int id);

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);
    }
}
