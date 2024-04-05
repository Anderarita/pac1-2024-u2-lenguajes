using ExamenUnidad2.Dtos;
using ExamenUnidad2.Dtos.IMC;

namespace ExamenUnidad2.Services.Interfaces
{
    public interface IIMCServices
    {
        Task<ResponceDto<IMCDto>> CreateAsync(IMCCreateDto model);
        Task<ResponceDto<IMCDto>> DeleteAsync(Guid id);
        Task<ResponceDto<IMCDto>> EditAsync(IMCEditDto dto, Guid id);
        Task<ResponceDto<List<IMCDto>>> GetListAsync(string searchTerm = "");
        Task<ResponceDto<IMCDto>> GetOneByIdAsync(Guid id);
    }
}
