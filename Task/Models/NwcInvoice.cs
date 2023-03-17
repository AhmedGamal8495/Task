using System;
using System.Collections.Generic;

namespace Task.Models;

public partial class NwcInvoice
{
    public string NwcInvoicesNo { get; set; } = null!;

    public string NwcInvoicesYear { get; set; } = null!;

    public string NwcInvoicesRrealEstateTypes { get; set; } = null!;

    public string NwcInvoicesSubscriptionNo { get; set; } = null!;

    public string NwcInvoicesSubscriberNo { get; set; } = null!;

    public DateTime NwcInvoicesDate { get; set; }

    public DateTime NwcInvoicesFrom { get; set; }

    public DateTime NwcInvoicesTo { get; set; }

    public int NwcInvoicesPreviousConsumptionAmount { get; set; }

    public int NwcInvoicesCurrentConsumptionAmount { get; set; }

    public int NwcInvoicesAmountConsumption { get; set; }

    public decimal NwcInvoicesServiceFee { get; set; }

    public decimal NwcInvoicesTaxRate { get; set; }

    public bool NwcInvoicesIsThereSanitation { get; set; }

    public decimal NwcInvoicesConsumptionValue { get; set; }

    public decimal NwcInvoicesWastewaterConsumptionValue { get; set; }

    public decimal NwcInvoicesTotalInvoice { get; set; }

    public decimal NwcInvoicesTaxValue { get; set; }

    public decimal NwcInvoicesTotalBill { get; set; }

    public string? NwcInvoicesTotalReasons { get; set; }

    public virtual NwcRrealEstateType NwcInvoicesRrealEstateTypesNavigation { get; set; } = null!;

    public virtual NwcSubscriberFile NwcInvoicesSubscriberNoNavigation { get; set; } = null!;

    public virtual NwcSubscriptionFile NwcInvoicesSubscriptionNoNavigation { get; set; } = null!;
}
