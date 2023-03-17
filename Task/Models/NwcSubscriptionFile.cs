using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace Task.Models;

public partial class NwcSubscriptionFile
{
    public string NwcSubscriptionFileNo { get; set; } = null!;

    public string NwcSubscriptionFileSubscriberCode { get; set; } = null!;

    public string NwcSubscriptionFileRrealEstateTypesCode { get; set; } = null!;

    public int NwcSubscriptionFileUnitNo { get; set; }

    public bool NwcSubscriptionFileIsThereSanitation { get; set; }

    public int NwcSubscriptionFileLastReadingMeter { get; set; }

    public string NwcSubscriptionFileReasons { get; set; } = null!;

    public virtual ICollection<NwcInvoice> NwcInvoices { get; } = new List<NwcInvoice>();

    public virtual NwcRrealEstateType NwcSubscriptionFileRrealEstateTypesCodeNavigation { get; set; } = null!;

    public virtual NwcSubscriberFile NwcSubscriptionFileSubscriberCodeNavigation { get; set; } = null!;
}
