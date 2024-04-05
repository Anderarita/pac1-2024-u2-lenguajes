
using AutoMapper;
using ExamenUnidad2.Dtos.IMC;
using ExamenUnidad2.Entities;

namespace ExamenUnidad2.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForTasks();
        }

        private void MapsForTasks()
        {
            CreateMap<IMCEntity, IMCDto>();
            CreateMap<IMCCreateDto, IMCEntity>();
            CreateMap<IMCEditDto, IMCEntity>();
            
        }

    }
}
