using Microsoft.EntityFrameworkCore;
using SalonBook.Server.Data.Main.Entities;

namespace SalonBook.Server.Data.Main.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public ChatRepository(IDbContextFactory<MainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddAsync(ChatMessage chatMessage)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Add(chatMessage);
                await context.SaveChangesAsync();
            }
        }
    }
}
