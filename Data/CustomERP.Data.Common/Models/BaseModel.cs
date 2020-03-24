namespace CustomERP.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string CreatedFrom { get; set; }

#nullable enable
        public string? ModifiedFrom { get; set; }
    }
}
