namespace CustomERP.Data.Common.Models
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        string CreatedFrom { get; set; }

#nullable enable
        string? ModifiedFrom { get; set; }
    }
}
