using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Common.Mappings;

namespace TaskBoard.Common.Models.ListCards
{
    public class CreateListCardsModel : IMapTo<Domain.Entities.ListCards>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
