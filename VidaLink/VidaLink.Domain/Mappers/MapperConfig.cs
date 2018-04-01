using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models;
using VidaLink.Domain.ViewModels;

namespace VidaLink.Domain.Mappers
{
    public class MapperConfig : IMapperConfig
    {
        private readonly IMapper _mapper;
        public IMapper Mapper { get { return _mapper; } }

        public MapperConfig()
        {
            var config = new MapperConfiguration(cfg => {
                #region Model && ViewModel

                cfg.CreateMap<Sessoes, SessoesViewModel>().ReverseMap();
                cfg.CreateMap<Tarefas, TarefasViewModel>().ReverseMap();
                cfg.CreateMap<Usuarios, UsuariosViewModel>().ReverseMap();
                

                #endregion
            });

            _mapper = config.CreateMapper();
        }
    }

    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}
