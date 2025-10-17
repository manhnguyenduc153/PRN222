using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class InventoryTransaction : EntityAuditBase<long>
{
    public string? TransactionCode { get; set; }

    public string TransactionType { get; set; } = null!;

    public long WarehouseId { get; set; }

    public string? ReferenceTable { get; set; }

    public long? ReferenceId { get; set; }

    public long? SupplierId { get; set; }

    public long? CustomerId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? Notes { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<InventoryTransactionDetail> InventoryTransactionDetails { get; set; } = new List<InventoryTransactionDetail>();

    public virtual Supplier? Supplier { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
