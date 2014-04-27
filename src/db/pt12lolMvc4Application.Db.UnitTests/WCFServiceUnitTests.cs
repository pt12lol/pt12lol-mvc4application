using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using pt12lolMvc4Application.Db.Repositories;
using pt12lolMvc4Application.Db.Service.WCF;
using IUserProfileDbService = pt12lolMvc4Application.Db.Service.WCF.IUserProfileDbService;

namespace pt12lolMvc4Application.Db.UnitTests
{
    [TestClass]
    public class WCFServiceUnitTests
    {
        readonly IUserProfileDbService _userProfileService;

        readonly IQueryable<UserProfile> fakeUserProfiles;
        readonly IQueryable<webpages_Membership> fakeMemberships;

        public WCFServiceUnitTests()
        {
            fakeUserProfiles = new[]
            {
                new UserProfile { UserId = 1, UserName = "pt12lol" },
                new UserProfile { UserId = 2, UserName = "user" },
                new UserProfile { UserId = 3, UserName = "test" }
            }.AsQueryable();

            fakeMemberships = new[]
            {
                new webpages_Membership { UserId = 1, Password = "hashedPass1", PasswordSalt = "secretSalt1" },
                new webpages_Membership { UserId = 2, Password = "hashedPass2", PasswordSalt = "secretSalt2" },
                new webpages_Membership { UserId = 3, Password = "hashedPass3", PasswordSalt = "secretSalt3" }
            }.AsQueryable();

            var userProfileRepositoryMock = new Mock<IEntitiesRepository<UserProfile>>();
            var membershipRepositoryMock = new Mock<IEntitiesRepository<webpages_Membership>>();

            userProfileRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<UserProfile, bool>>>()))
                .Returns<Expression<Func<UserProfile, bool>>>(pred => fakeUserProfiles.Where(pred));
            membershipRepositoryMock.Setup(r => r.Get(It.IsAny<int>()))
                .Returns<int>(id => fakeMemberships.FirstOrDefault(m => m.UserId == id));
            membershipRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<webpages_Membership, bool>>>()))
                .Returns<Expression<Func<webpages_Membership, bool>>>(pred => fakeMemberships.Where(pred));

            _userProfileService = new UserProfileDbService(() => userProfileRepositoryMock.Object, () => membershipRepositoryMock.Object);
        }

        [TestMethod]
        public void GetUserProfileByUserNameTest()
        {
            Assert.AreEqual(_userProfileService.GetUserProfileByUserName("pt12lol"),
                new Models.UserProfile { UserId = 1, UserName = "pt12lol" });
            Assert.IsNull(_userProfileService.GetUserProfileByUserName("x"));
        }

        [TestMethod]
        public void GetMembershipByUserNameTest()
        {
            var membership = _userProfileService.GetMembershipByUserName("user");
            Assert.AreEqual(membership.UserId, 2);
            Assert.AreEqual(membership.Password, "hashedPass2");
            Assert.AreEqual(membership.PasswordSalt, "secretSalt2");

            Assert.IsNull(_userProfileService.GetMembershipByUserName("y"));
        }

        [TestMethod]
        public void GetPasswordSaltByUserNameTest()
        {
            Assert.AreEqual(_userProfileService.GetPasswordSaltByUserName("test"), "secretSalt3");
            Assert.IsNull(_userProfileService.GetMembershipByUserName("z"));
        }
    }
}
