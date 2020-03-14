using SecretSanta.Data.EF.Repositories.GroupRepository;
using SecretSanta.Data.EF.Repositories.RecipientRepository;
using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.Models;
using SecretSanta.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.GroupService
{
    public class GroupService : IGroupService
    {
        public GroupService(IGroupRepository groupRepository, IUserRepository userRepository, IRecipientRepository recipientRepository)
        {
            _recipientRepository = recipientRepository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
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

        public void SetRecipient(Group group)
        {
            var currentGroup = GetGroup(group.Id);
            List<User> users = _userRepository.Get(u => u.GroupId == group.Id).ToList();
            users.Mix();
            _recipientRepository.SetRecipientForUsers(users);
        }

        private IGroupRepository _groupRepository;
        private IUserRepository _userRepository;
        private IRecipientRepository _recipientRepository;
    }
}
