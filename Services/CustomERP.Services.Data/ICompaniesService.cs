namespace CustomERP.Services.Data
{
    using System.Collections.Generic;

    public interface ICompaniesService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
