using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IMembreService
    {
        IEnumerable<MembreDto> GetMemberList();
        //Task<IEnumerable<MembreBasicDto>> GetMemberListAsync();
        MembreDetailDto GetMemberDetail(int id);
        void DeleteMember(int id);
    }
}
