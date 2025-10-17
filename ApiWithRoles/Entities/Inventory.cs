using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class Inventory : EntityAuditBase<long>
{
    public long ProductId { get; set; }

    public int? QuantityOnHand { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual Warehouse IdNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
