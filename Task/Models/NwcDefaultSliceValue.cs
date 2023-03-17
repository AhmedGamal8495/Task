using System;
using System.Collections.Generic;

namespace Task.Models;

public partial class NwcDefaultSliceValue
{
    public string NwcDefaultSliceValuesCode { get; set; } = null!;

    public string NwcDefaultSliceValuesName { get; set; } = null!;

    public int NwcDefaultSliceValuesCondtion { get; set; }

    public decimal NwcDefaultSliceValuesWaterPrice { get; set; }

    public decimal NwcDefaultSliceValuesSanitationPrice { get; set; }

    public string NwcDefaultSliceValuesReasons { get; set; } = null!;
}
