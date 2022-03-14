namespace ApiService.Infrastructure
{
    using System.Threading.Tasks;
    using ApiService.Contracts.Queries;

    public interface ICommandServiceClient
    {
        Task SendPlatformToCommand(PlatformReadQuery query);
    }
}