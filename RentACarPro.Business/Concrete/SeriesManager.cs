using RentACarPro.Business.Abstract;
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

        public List<Series> GetAllSeries()
        {
            return _seriesDal.GetAll();
        }
    }
}
