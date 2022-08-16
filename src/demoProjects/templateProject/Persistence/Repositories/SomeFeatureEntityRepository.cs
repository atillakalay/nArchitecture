using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SomeFeatureEntityRepository : EfRepositoryBase<SomeFeatureEntity, BaseDbContext>, ISomeFeatureEntityRepository
    {
        public SomeFeatureEntityRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
