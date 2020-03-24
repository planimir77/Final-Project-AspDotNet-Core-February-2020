namespace CustomERP.Data.Common.Models
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }

#nullable enable
        string? DeletedFrom { get; set; }
    }
}
