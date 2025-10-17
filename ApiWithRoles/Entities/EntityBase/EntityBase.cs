namespace ApiWithRoles.Entities.EntityBase
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
