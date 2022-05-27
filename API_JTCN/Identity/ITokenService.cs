using DataTransferObjects;

namespace API_JTCN.Identity
{
    public interface ITokenService
    {
        string GenerateToken(int id, string role);
    }
}
