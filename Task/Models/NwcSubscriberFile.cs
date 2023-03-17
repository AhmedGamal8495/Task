using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task.Models;

public partial class NwcSubscriberFile
{
    [MinLength(10)]
    [MaxLength(10)]
    public string NwcSubscriberFileId { get; set; } = null!;

    public string NwcSubscriberFileName { get; set; } = null!;

    public string NwcSubscriberFileCity { get; set; } = null!;

    public string NwcSubscriberFileArea { get; set; } = null!;

    public string NwcSubscriberFileMobile { get; set; } = null!;

    public string NwcSubscriberFileReasons { get; set; } = null!;

    public virtual ICollection<NwcInvoice> NwcInvoices { get; } = new List<NwcInvoice>();

    public virtual ICollection<NwcSubscriptionFile> NwcSubscriptionFiles { get; } = new List<NwcSubscriptionFile>();
}
