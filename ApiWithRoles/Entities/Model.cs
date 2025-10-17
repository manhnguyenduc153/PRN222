using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class Model : EntityAuditBase<long>
{
    public long? BrandId { get; set; }

    public long? CategoryId { get; set; }

    public string? ModelName { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Version> Versions { get; set; } = new List<Version>();
}
