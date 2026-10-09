using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban.Dtos;
using Kanban.Entities;

namespace API.Helpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TaskCard, TaskCardDto>()
                                    .ReverseMap();
    }
}