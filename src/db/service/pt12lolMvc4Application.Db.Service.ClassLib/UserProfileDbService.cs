using System;
using System.Linq;
using AutoMapper;
using pt12lolMvc4Application.Db.Repositories;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public class UserProfileDbService : IUserProfileDbService
    {
        IDbRepository<UserProfile> _userProfileRepository;
        IDbRepository<webpages_Membership> _membershipRepository;
        readonly Func<IDbRepository<UserProfile>> _userProfileRepositoryInitializer;
        readonly Func<IDbRepository<webpages_Membership>> _membershipRepositoryInitializer;

        public UserProfileDbService()
        {
            _userProfileRepositoryInitializer = () => new DbRepository<UserProfile>();
            _membershipRepositoryInitializer = () => new DbRepository<webpages_Membership>();
        }

        public UserProfileDbService(Func<IDbRepository<UserProfile>> userProfileRepositoryInitializer, Func<IDbRepository<webpages_Membership>> membershipRepositoryInitializer)
        {
            _userProfileRepositoryInitializer = userProfileRepositoryInitializer;
            _membershipRepositoryInitializer = membershipRepositoryInitializer;
        }

        public Models.UserProfile GetUserProfileByName(string name)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                return Mapper.Map<Models.UserProfile>(_userProfileRepository.Get(u => u.UserName.Equals(name)).FirstOrDefault());
            }
        }

        public void AddUser(Models.UserProfile toAdd)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                _userProfileRepository.Insert(Mapper.Map<UserProfile>(toAdd));
                _userProfileRepository.Save();
            }
        }

        public string GetSaltByUserName(string name)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                int userId = _userProfileRepository.Get(u => u.UserName.Equals(name)).First().UserId;
                using (_membershipRepository = _membershipRepositoryInitializer())
                {
                    return _membershipRepository.Get(userId).PasswordSalt;
                }
            }
        }

        public void UpdateMembership(Models.webpages_Membership toUpdate)
        {
            using (_membershipRepository = _membershipRepositoryInitializer())
            {
                _membershipRepository.Update(Mapper.Map<webpages_Membership>(toUpdate));
                _membershipRepository.Save();
            }
        }


        public Models.webpages_Membership GetMembershipByUserName(string userName)
        {
            using (_userProfileRepository = _userProfileRepositoryInitializer())
            {
                int userId = _userProfileRepository.Get(u => u.UserName.Equals(userName)).First().UserId;
                using (_membershipRepository = _membershipRepositoryInitializer())
                {
                    return Mapper.Map<Models.webpages_Membership>(_membershipRepository.Get(userId));
                }
            }
        }
    }
}
