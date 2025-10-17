namespace ApiWithRoles.Entities.EntityBase
{
    public abstract class EntityAuditBase<T> : EntityBase<T>
    {
        public string? CreateBy { get; set; }
        public long? CreateDate { get; set; }
    }
}
