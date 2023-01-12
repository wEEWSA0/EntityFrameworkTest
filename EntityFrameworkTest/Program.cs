using EntityFrameworkTest.DbConnection;
using EntityFrameworkTest.DbEntities;
using EntityFrameworkTest.Repositories;

DbManager dbManager = new DbManager();

UsersRepository usersRepository = new UsersRepository(dbManager);
PlaceRepository placeRepository = new PlaceRepository(dbManager);

foreach (User user in usersRepository.GetAllUsers())
{
    Console.WriteLine(user);
}