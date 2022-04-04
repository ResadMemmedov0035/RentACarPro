using Core.Utilities.Results;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Constants;
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

        public IResult Add(Series series)
        {
            try
            {
                if (series.Name.Length < 2)
                    throw new Exception("Series name length must be greater than 2");

                _seriesDal.Add(series);
                return new SuccessResult(Messages.AddSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult Delete(Series series)
        {
            try
            {
                _seriesDal.Delete(series);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            
        }

        public IResult Update(Series series)
        {
            try
            {
                if (series.Name.Length < 2)
                    throw new Exception("Series name length must be greater than 2");

                _seriesDal.Update(series);
                return new SuccessResult(Messages.UpdateSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            
        }
    }
}
