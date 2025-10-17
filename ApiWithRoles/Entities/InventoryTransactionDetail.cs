using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class InventoryTransactionDetail : EntityAuditBase<long>
{
    public long? TransactionId { get; set; }

    public long? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual InventoryTransaction? Transaction { get; set; }
}
