using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class SomeFeatureEntity : Entity
    {
        public string Name { get; set; }

        public SomeFeatureEntity()
        {

        }

        public SomeFeatureEntity(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
