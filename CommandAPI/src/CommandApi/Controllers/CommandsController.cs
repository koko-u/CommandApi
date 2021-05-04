using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandApi.Dtos;
using CommandApi.Models;
using CommandApi.Repositories;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandApiRepository _repository;
        private readonly IMapper _mapper;

        public CommandsController(
            ICommandApiRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}", Name = nameof(GetCommandById))]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            return command.Match<ActionResult<CommandReadDto>>(
                found => Ok(_mapper.Map<CommandReadDto>(found)),
                () => NotFound()
            );
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto dto)
        {
            var command = _mapper.Map<Command>(dto);
            _repository.CreateCommand(command);
            _repository.SaveChanges();
            // after call SaveChanges, it affects command instance's Id property.

            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto dto)
        {
            var optCommand = _repository.GetCommandById(id);
            return optCommand.Match<ActionResult>(
                some: (command) =>
                {
                    _mapper.Map(dto, command);
                    _repository.UpdateCommand(command);  // no effect
                    _repository.SaveChanges();

                    return NoContent();
                },
                none: NotFound
                );
        }
}
}
