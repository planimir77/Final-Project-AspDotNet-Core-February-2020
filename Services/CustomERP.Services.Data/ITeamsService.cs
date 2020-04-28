namespace CustomERP.Services.Data
{
    using System.Collections.Generic;

    public interface ITeamsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
