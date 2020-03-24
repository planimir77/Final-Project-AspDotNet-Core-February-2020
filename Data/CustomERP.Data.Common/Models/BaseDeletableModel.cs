namespace CustomERP.Data.Common.Models
{
    using System;

    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

#nullable enable
        public string? DeletedFrom { get; set; }
    }
}
