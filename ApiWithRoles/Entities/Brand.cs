using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class Brand : EntityAuditBase<long>
{

    public string? BrandName { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
