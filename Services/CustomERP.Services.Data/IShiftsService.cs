namespace CustomERP.Services.Data
{
    using System.Collections.Generic;

    public interface IShiftsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
