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

        public void AddSeries(Series series)
        {
            if (series.Name.Length < 2) 
                throw new Exception("Series name length must be greater than 2");

            _seriesDal.Add(series);
        }

        public void DeleteSeries(Series series)
        {
            _seriesDal.Delete(series);
        }

        public List<Series> GetAllSeries()
        {
            return _seriesDal.GetAll();
        }

        public Series? GetSeriesById(int id)
        {
            return _seriesDal.Get(s => s.Id == id);
        }

        public void UpdateSeries(Series series)
        {
            if (series.Name.Length < 2)
                throw new Exception("Series name length must be greater than 2");

            _seriesDal.Update(series);
        }
    }
}
