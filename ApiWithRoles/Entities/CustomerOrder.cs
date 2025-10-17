using ApiWithRoles.Entities.EntityBase;
using System;
using System.Collections.Generic;

namespace ApiWithRoles.Entities;

public partial class CustomerOrder : EntityAuditBase<long>
{
    public string? OrderCode { get; set; }

    public long? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }
}
