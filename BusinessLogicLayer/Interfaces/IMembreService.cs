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
        MembreDto GetMemberDetail(int id);
        void CreateNewMember(MembreForCreationDto member);
        //void DeleteMember(int id);
    }
}
