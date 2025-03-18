namespace IWant.Web.Service
{
    public interface ILeaderboardService
    {
        Task<LeaderboardResponse> GetLeaderboardsAsync();
    }
}