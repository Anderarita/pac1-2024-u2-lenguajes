using AutoMapper;
using ExamenUnidad2.Database;
using System.Runtime.CompilerServices;
using ExamenUnidad2.Dtos;
using ExamenUnidad2.Dtos.IMC;
using ExamenUnidad2.Entities;
using ExamenUnidad2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad2.Services
{
    public class IMCServices : IIMCServices

    {
        private readonly IMCDbContext _context;
        private readonly IMapper _mapper;

        public IMCServices(
            IMCDbContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponceDto<List<IMCDto>>> GetListAsync(string searchTerm = "")
        {
            var tasksEntity = await _context.IMC
               .Where(t => t.Name.Contains(searchTerm)).ToListAsync();



            var tasksDto = _mapper.Map<List<IMCDto>>(tasksEntity);

            return new ResponceDto<List<IMCDto>>
            {
                Status = true,
                StatusCode = 200,
                Message = "Datos obtenidos correctamnente",
                Data = tasksDto
            };
        }

        public async Task<ResponceDto<IMCDto>> CreateAsync(IMCCreateDto model)
        {

            var taskEntity = _mapper.Map<IMCEntity>(model);

            _context.IMC.Add(taskEntity);
            await _context.SaveChangesAsync();

            var taskDto = _mapper.Map<IMCDto>(taskEntity);


            return new ResponceDto<IMCDto>
            {
                Status = true,
                StatusCode = 201,
                Message = "Tarea creada correctamente",
                Data = taskDto
            };
        }

        public async Task<ResponceDto<IMCDto>> GetOneByIdAsync(Guid id)
        {
            var taskEntity = await _context.IMC.FirstOrDefaultAsync(t => t.Id == id);

            if (taskEntity == null)
            {
                return new ResponceDto<IMCDto>
                {
                    Status = true,
                    StatusCode = 404,
                    Message = $" Tarea{id} no encontrada"
                };
            }



            var taskDto = _mapper.Map<IMCDto>(taskEntity);

            return new ResponceDto<IMCDto>
            {
                Status = true,
                StatusCode = 200,
                Message = $" Tarea{taskDto.Id} encontrada",
                Data = taskDto
            };
        }

        public async Task<ResponceDto<IMCDto>> EditAsync(IMCEditDto dto, Guid id)
        {
            var taskEntity = await _context.IMC.FirstOrDefaultAsync(t => t.Id == id);

            if (taskEntity is null)
            {
                return new ResponceDto<IMCDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"Tarea {id} no encontrada"
                };
            }

            _mapper.Map<IMCEditDto, IMCEntity>(dto, taskEntity);

            _context.Update(taskEntity);
            await _context.SaveChangesAsync();

            var taskDto = _mapper.Map<IMCDto>(taskEntity);

            return new ResponceDto<IMCDto>
            {
                StatusCode = 200,
                Status = true,
                Message = $"la tarea {id} ha sido modificada",
                Data = taskDto
            };
        }

        public async Task<ResponceDto<IMCDto>> DeleteAsync(Guid id)
        {
            var taskEntyti = await _context.IMC.FirstOrDefaultAsync(t => t.Id == id);

            if (taskEntyti is null)
            {
                return new ResponceDto<IMCDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = " Tarea no encontrada"
                };

            }
            _context.Remove(taskEntyti);
            await _context.SaveChangesAsync();

            return new ResponceDto<IMCDto>
            {
                StatusCode = 200,
                Status = true,
                Message = " Tarea borrada con exito"
            };
        }
    }
}
