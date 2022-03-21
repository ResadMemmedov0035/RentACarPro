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
        List<Series> GetAllSeries();
        Series? GetSeriesById(int id);
        void AddSeries(Series series);
        void UpdateSeries(Series series);
        void DeleteSeries(Series series);
    }
}
