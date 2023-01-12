using EntityFrameworkTest.DbConnection;
using EntityFrameworkTest.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Repositories;

public class UsersRepository
{
    private DbManager _dbManager;

    public UsersRepository(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    public List<User> GetAllUsers()
    {
        return _dbManager.Users
            .Include(user => user.Place)
            .ToList();
    }

    public User GetById(int id)
    {
        return _dbManager.Users
            .Include(user => user.Place)
            .First(user => user.Id == id);
    }

    public void AddNewUser(User user)
    {
        _dbManager.Users.Add(user);
        _dbManager.SaveChanges();
    }

    public void DeleteUserById(int id)
    {
        User user = _dbManager.Users.First(user => user.Id == id);
        _dbManager.Users.Remove(user);
        _dbManager.SaveChanges();
    }

    public void UpdateUser(User newUser)
    {
        User oldUser = _dbManager.Users.First(user => user.Id == newUser.Id);

        oldUser.Name = newUser.Name;
        oldUser.PlaceId = newUser.PlaceId;

        _dbManager.SaveChanges();
    }
}