using Business.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(message:"Model ekleme işlemi başarılı");
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult(message: "Model ekleme silme başarılı");
        }

        public IDataResult<List<Model>> GetAll()
        {
            var result = _modelDal.GetAll(includes: p => p.Brand);

            if(result.Count != 0)
            {
                return new SuccessDataResult<List<Model>>(data: result, message: "Model listeleme işlemi başarılı");
            }

            return new ErrorDataResult<List<Model>>(data: null, message: "Listelenecek model bilgisine ulaşılamadı");
        }

        public IDataResult<Model> GetById(int id)
        {
            var result = _modelDal.Get(p => p.Id.Equals(id));

            if(result is not null)
            {
                return new SuccessDataResult<Model>(data: result, message: "Model bulundu");
            }

            return new ErrorDataResult<Model>(data: null, message: "Model bulunamadı");
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(message: "Model ekleme silme başarılı");
        }
    }
}
