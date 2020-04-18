namespace CustomERP.Services.Data
{
    using System.Collections.Generic;

    public interface IShiftsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
