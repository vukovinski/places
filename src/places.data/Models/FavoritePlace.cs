namespace places.data
{
    public class FavoritePlace
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public required string PlaceId { get; set; }

        public Place? Place { get; set; } = null;
        public UserAccount? UserAccount { get; set; } = null;
    }
}
