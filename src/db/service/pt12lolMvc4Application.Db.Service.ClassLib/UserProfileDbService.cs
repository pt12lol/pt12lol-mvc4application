using System;
using System.Linq;
using AutoMapper;
using pt12lolMvc4Application.Db.Repositories;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public class UserProfileDbService : IUserProfileDbService
    {
        IEntitiesRepository<UserProfile> _userProfileRepository;
        IEntitiesRepository<webpages_Membership> _membershipRepository;
        readonly Func<IEntitiesRepository<UserProfile>> _userProfileRepositoryInitializer;
        readonly Func<IEntitiesRepository<webpages_Membership>> _membershipRepositoryInitializer;

        public UserProfileDbService()
        {
            _userProfileRepositoryInitializer = () => new EntitiesRepository<UserProfile>();
            _membershipRepositoryInitializer = () => new EntitiesRepository<webpages_Membership>();
        }

        public UserProfileDbService(Func<IEntitiesRepository<UserProfile>> userProfileRepositoryInitializer, Func<IEntitiesRepository<webpages_Membership>> membershipRepositoryInitializer)
        {
            _userProfileRepositoryInitializer = userProfileRepositoryInitializer;
            _membershipRepositoryInitializer = membershipRepositoryInitializer;
        }

        public Models.UserProfile GetUserProfileByUserName(string name)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                return Mapper.Map<UserProfile, Models.UserProfile>(_userProfileRepository.Get(u => u.UserName.Equals(name)).FirstOrDefault());
            }
        }

        public Models.webpages_Membership GetMembershipByUserName(string userName)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                IQueryable<UserProfile> foundUserProfilesByName = _userProfileRepository.Get(u => u.UserName.Equals(userName));
                int userId = foundUserProfilesByName.Any() ? foundUserProfilesByName.First().UserId : 0;
                using (_membershipRepository = _membershipRepositoryInitializer())
                {
                    return Mapper.Map<webpages_Membership, Models.webpages_Membership>(_membershipRepository.Get(userId));
                }
            }
        }

        public string GetPasswordSaltByUserName(string userName)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                IQueryable<UserProfile> foundUserProfilesByName = _userProfileRepository.Get(u => u.UserName.Equals(userName));
                int userId = foundUserProfilesByName.Any() ? foundUserProfilesByName.First().UserId : 0;
                using (_membershipRepository = _membershipRepositoryInitializer())
                {
                    return _membershipRepository.Get(userId).PasswordSalt;
                }
            }
        }

        public void AddUser(Models.UserProfile toAdd)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                _userProfileRepository.Insert(Mapper.Map<Models.UserProfile, UserProfile>(toAdd));
                _userProfileRepository.Save();
            }
        }

        public void UpdateMembership(Models.webpages_Membership toUpdate)
        {
            using (_membershipRepository = _membershipRepositoryInitializer())
            {
                _membershipRepository.Update(Mapper.Map<Models.webpages_Membership, webpages_Membership>(toUpdate));
                _membershipRepository.Save();
            }
        }
    }
}
