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
        IEnumerable<MembreForListDto> GetMemberList();
        //Task<IEnumerable<MembreBasicDto>> GetMemberListAsync();
        MembreDto GetMemberDetail(int id);
        void DeleteMember(int id);
    }
}
