using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Domain.Mappers
{
    public interface IMapperConfig
    {
        IMapper Mapper { get; }
    }
}
