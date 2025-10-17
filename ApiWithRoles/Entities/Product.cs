using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class Product : EntityAuditBase<long>
{
    public string? ProductName { get; set; }

    public long? CategoryId { get; set; }

    public long? BrandId { get; set; }

    public long? ModelId { get; set; }

    public long? VersionId { get; set; }

    public string? Unit { get; set; }

    public decimal? BasePrice { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<InventoryTransactionDetail> InventoryTransactionDetails { get; set; } = new List<InventoryTransactionDetail>();

    public virtual Model? Model { get; set; }

    public virtual Version? Version { get; set; }
}
