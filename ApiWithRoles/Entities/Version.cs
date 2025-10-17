using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class Version : EntityAuditBase<long>
{
    public long? ModelId { get; set; }

    public long? CategoryId { get; set; }

    public long? BrandId { get; set; }

    public string? VersionName { get; set; }

    public virtual Model? Model { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
