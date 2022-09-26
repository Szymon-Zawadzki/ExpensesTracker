using ExpensesTracker.Models.Resource;

namespace ExpensesTracker.Interfaces
{
    public interface IResourceServices
    {
        IEnumerable<ResourceDto> GetAll();
        ResourceDto GetById(int id);
        string Create(CreateResourceDto dto);
        string Update(UpdateResourceDto dto, int id);
        string DeleteById(int id);
        string Delete();
    }
}
