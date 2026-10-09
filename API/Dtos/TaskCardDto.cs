using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Dtos;
public class TaskCardDto
{
    public int id { get; set; }   
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Status { get; set; }
    public DateOnly AddedDate { get; set; }
    public DateOnly DueDate { get; set; }
}
