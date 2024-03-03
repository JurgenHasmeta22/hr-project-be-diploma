using DTO.UserDTO;

namespace Domain.Contracts
{
    public interface IAftesiDomain
    {
        AftesiDTO AddAftesi(AftesiPostDTO aftesi);
        IList<AftesiDTO> getAllAftesi();
        AftesiDTO GetAftesiById(Guid AftesiId);

        void PutAftesi(Guid AftesiId, AftesiPostDTO aftesi);
        void DeleteAftesi(Guid AftesiId);
    }
}
