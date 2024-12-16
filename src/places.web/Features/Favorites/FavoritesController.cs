using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using places.data;

namespace places.web
{
    [Route("api/favorites")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private int UserAccountId => int.Parse(User.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);

        private readonly PlacesDbContext _dbContext;
        private readonly IFavoritePlacesService _favoritePlacesService;

        public FavoritesController(
            PlacesDbContext dbContext,
            IFavoritePlacesService favoritePlacesService)
        {
            _dbContext = dbContext;
            _favoritePlacesService = favoritePlacesService;
        }

        [HttpPut("{placeId}")]
        public IActionResult PutFavorite(string placeId)
        {
            try
            {
                var place = _dbContext.Places.Find(placeId);
                var userAccount = _dbContext.UserAccounts.Find(UserAccountId);
                _favoritePlacesService.MakeFavorite(userAccount!, place!);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{placeId}")]
        public IActionResult DeleteFavorite(string placeId)
        {
            try
            {
                var place = _dbContext.Places.Find(placeId);
                var userAccount = _dbContext.UserAccounts.Find(UserAccountId);
                _favoritePlacesService.UnmakeFavorite(userAccount!, place!);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetFavorites()
        {
            try
            {
                var favorites = _dbContext.FavoritePlaces.Where(fp => fp.UserAccountId == UserAccountId).Select(fp => fp.PlaceId).ToHashSet();
                var favoritePlaces = _dbContext.Places.Where(p => favorites.Contains(p.Id));
                return Ok(new PlacesWebResponse
                {
                    Places = favoritePlaces.Select(p => new PlaceItem()
                    {
                        Id = p.Id,
                        Type = p.Type,
                        LocationName = p.LocationName,
                        Location = $"{p.Latitude}/{p.Longitude}"

                    }).ToList()
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
