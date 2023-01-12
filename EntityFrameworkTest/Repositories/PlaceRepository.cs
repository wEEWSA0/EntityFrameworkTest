using EntityFrameworkTest.DbConnection;
using EntityFrameworkTest.DbEntities;

namespace EntityFrameworkTest.Repositories;

public class PlaceRepository
{
    private DbManager _dbManager;

    public PlaceRepository(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    public Rank GetById(int id)
    {
        return _dbManager.Ranks.First(country => country.Id == id);
    }

    public List<Rank> GetAllRanks()
    {
        return _dbManager.Ranks.ToList();
    }
}