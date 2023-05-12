namespace AuthenicationService.Repopsitory
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        public UserRepository()
        {
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName= "Test",
                LastName= "Test",
                Email= "Test@mail.ru",
                Login = "test",
                Password  ="11",
                Role = new Role()
                {
                    Id = 1,
                    Name= "Пользователь"
                }
            });
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "TestIvan",
                LastName = "TestIvanov",
                Email = "Ivanov@mail.ru",
                Login = "admin",
                Password = "22",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Администратор"
                }
            });
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "TestPetr",
                LastName = "TestPetrov",
                Email = "Petrov@mail.ru",
                Login = "testPetrov",
                Password = "333333",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });

        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(v => v.Login == login);
        }
    }
}
