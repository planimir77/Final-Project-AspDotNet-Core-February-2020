namespace CustomERP.Services.Data
{
    using System.Collections.Generic;

    public interface IDepartmentsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
