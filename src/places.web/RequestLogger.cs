using places.data;

using System.Text.Json;

namespace places.web
{
    public class RequestLogger : IRequestLogger
    {
        private readonly PlacesDbContext _dbContext;

        public RequestLogger(PlacesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Log(object request, object response)
        {
            _dbContext.RequestLog.Add(new RequestLog
            {
                TimeStamp = DateTime.UtcNow,
                RequestData = JsonSerializer.Serialize(request),
                ResponseData = JsonSerializer.Serialize(response),
            });
            _dbContext.SaveChanges();
        }
    }

    public interface IRequestLogger
    {
        void Log(object request, object response);
    }
}
