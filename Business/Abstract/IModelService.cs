using Entities.Concrete;

namespace Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetAll();
        Model GetById(int id);
        void Add(Model model);
        void Update(Model model);
        void Delete(Model model);
    }
}
