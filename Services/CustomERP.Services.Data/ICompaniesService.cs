namespace CustomERP.Services.Data
{
    using System.Collections.Generic;

    public interface ICompaniesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
