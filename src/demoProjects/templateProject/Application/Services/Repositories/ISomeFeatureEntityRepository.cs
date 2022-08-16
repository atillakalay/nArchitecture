using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ISomeFeatureEntityRepository : IAsyncRepository<SomeFeatureEntity>, IRepository<SomeFeatureEntity>
    {
    }
}
