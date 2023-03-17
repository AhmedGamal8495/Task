using System;
using System.Collections.Generic;

namespace Task.Models;

public partial class NwcRrealEstateType
{
    public string NwcRrealEstateTypesCode { get; set; } = null!;

    public string NwcRrealEstateTypesName { get; set; } = null!;

    public string NwcRrealEstateTypesReasons { get; set; } = null!;

    public virtual ICollection<NwcInvoice> NwcInvoices { get; } = new List<NwcInvoice>();

    public virtual ICollection<NwcSubscriptionFile> NwcSubscriptionFiles { get; } = new List<NwcSubscriptionFile>();
}
