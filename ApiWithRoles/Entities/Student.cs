using ApiWithRoles.Entities.EntityBase;

namespace ApiWithRoles.Entities
{
    public class Student : EntityAuditBase<long>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
