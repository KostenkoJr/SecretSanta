using SecretSanta.Data.EF.Repositories.GroupRepository;
using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.GroupService
{
    public class GroupService : IGroupService
    {
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public void CreateGroup(Group group)
        {
            _groupRepository.Create(group);
        }

        public void DeleteGroup(Group group)
        {
            _groupRepository.Delete(group);
        }

        public IEnumerable<Group> GetGroups()
        {
            return _groupRepository.Get();
        }
        public Group GetGroup(long id)
        {
            return _groupRepository.Get(id);
        }

        public void UpdateGroup(Group group)
        {
            _groupRepository.Update(group);
        }

        private IGroupRepository _groupRepository;
    }
}
