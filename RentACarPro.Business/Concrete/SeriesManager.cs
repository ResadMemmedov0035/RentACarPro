using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Constants;
using RentACarPro.Business.ValidationRules.FluentValidation;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.Business.Concrete
{
    public class SeriesManager : ISeriesService
    {
        private readonly ISeriesDal _seriesDal;

        public SeriesManager(ISeriesDal seriesDal)
        {
            _seriesDal = seriesDal;
        }

        public IDataResult<List<Series>> GetAll()
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll());
        }

        public IDataResult<Series?> GetById(int id)
        {
            return new SuccessDataResult<Series?>(_seriesDal.Get(s => s.Id == id));
        }

        [ValidationAspect(typeof(SeriesValidator))]
        public IResult Add(Series series)
        {
            _seriesDal.Add(series);
            return new SuccessResult(Messages.AddSuccess);
        }

        [ValidationAspect(typeof(SeriesValidator))]
        public IResult Update(Series series)
        {
            _seriesDal.Update(series);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        public IResult Delete(Series series)
        {
            _seriesDal.Delete(series);
            return new SuccessResult(Messages.DeleteSuccess);
        }
    }
}
