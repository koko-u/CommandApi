using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandApi.Dtos;
using CommandApi.Models;

namespace CommandApi.Profiles
{
    public class CommandsProfile : Profile
    {
        /// <inheritdoc />
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
