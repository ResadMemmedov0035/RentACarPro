using Core.Utilities.Results;
using RentACarPro.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.Business.Abstract
{
    public interface ISeriesService
    {
        IDataResult<List<Series>> GetAll();
        IDataResult<Series> GetById(int id);
        IResult Add(Series series);
        IResult Update(Series series);
        IResult Delete(Series series);
    }
}
