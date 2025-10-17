using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class Category : EntityAuditBase<long>
{

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
