using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.GroupService
{
    public interface IGroupService
    {
        Group GetGroup(Int64 id);
        IEnumerable<Group> GetGroups();
        void CreateGroup(Group group);
        void DeleteGroup(Group group);
        void UpdateGroup(Group group);
    }
}
