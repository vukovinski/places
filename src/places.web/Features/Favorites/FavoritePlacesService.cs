using places.data;

namespace places.web
{
    public class FavoritePlacesService : IFavoritePlacesService
    {
        private readonly PlacesDbContext _dbContext;

        public FavoritePlacesService(PlacesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FavoritePlace[] GetFavorites(UserAccount account)
        {
            return _dbContext.FavoritePlaces.Where(fp => fp.UserAccountId == account.Id).ToArray();
        }

        public void MakeFavorite(UserAccount account, Place place)
        {
            _dbContext.FavoritePlaces.Add(new FavoritePlace
            {
                PlaceId = place.Id,
                UserAccountId = account.Id
            });
            _dbContext.SaveChanges();
        }

        public void UnmakeFavorite(UserAccount account, Place place)
        {
            var candidate = _dbContext.FavoritePlaces.FirstOrDefault(fp => fp.UserAccountId == account.Id && fp.PlaceId == place.Id);
            if (candidate != null)
            {
                _dbContext.FavoritePlaces.Remove(candidate);
                _dbContext.SaveChanges();
            }
        }
    }

    public interface IFavoritePlacesService
    {
        void MakeFavorite(UserAccount account, Place place);
        void UnmakeFavorite(UserAccount account, Place place);

        FavoritePlace[] GetFavorites(UserAccount account);
    }
}
