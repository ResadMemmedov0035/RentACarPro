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
        IDataResult<List<Series>> GetAllSeries();
        IDataResult<Series?> GetSeriesById(int id);
        IResult AddSeries(Series series);
        IResult UpdateSeries(Series series);
        IResult DeleteSeries(Series series);
    }
}
