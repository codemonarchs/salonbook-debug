using SalonBook.Server.Data.Main.Entities;

namespace SalonBook.Server.Data.Main.Repositories
{
    public interface IChatRepository
    {
        Task AddAsync(ChatMessage chatMessage);
    }
}
