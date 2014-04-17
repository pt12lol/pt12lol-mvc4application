using System;
using System.Linq;
using AutoMapper;
using pt12lolMvc4Application.Db.Repositories;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public class UserProfileDbService : IUserProfileDbService
    {
        IDbRepository<UserProfile> _repository;
        readonly Func<IDbRepository<UserProfile>> _initializer;

        public UserProfileDbService()
        {
            _initializer = () => new DbRepository<UserProfile>();
        }

        public UserProfileDbService(Func<IDbRepository<UserProfile>> initializer)
        {
            _initializer = initializer;
        }

        public Models.UserProfile GetUserProfileByName(string name)
        {
            using (_repository = _initializer())
            {
                return Mapper.Map<Models.UserProfile>(_repository.Get(u => u.UserName.Equals(name)).FirstOrDefault());
            }
        }

        public void AddUser(Models.UserProfile toAdd)
        {
            using (_repository = _initializer())
            {
                _repository.Insert(Mapper.Map<Models.UserProfile, UserProfile>(toAdd));
                _repository.Save();
            }
        }
    }
}
