﻿
using Events.DAL.Entities;
using Events.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.DAL.Data.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(EventContext context) : base(context) { }

        public override async Task<Tag> GetCompleteEntityAsync(int id)
        {
            var tag = await table.Include(t => t.Event)
                                 .SingleOrDefaultAsync(t => t.Id == id);

            return tag;
        }

        public async Task<IEnumerable<Tag>> GetTagsByIds(int[] ids)
        {
            return await table.Where(t => ids.Contains(t.Id)).ToListAsync();
        }
    }
}
