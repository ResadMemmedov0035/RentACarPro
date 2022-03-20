using RentACarPro.DataAccess.Abstract;
using RentACarPro.DataAccess.Concrete.InMemory;
using RentACarPro.DataAccess.Concrete.EntityFramework;
using RentACarPro.Entities.Concrete;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Concrete;

ISeriesService seriesService = new SeriesManager(new EfSeriesDal());
foreach (var series in seriesService.GetAllSeries())
{
    Console.WriteLine("{0} - {1} [{2}]", series.Id, series.Name, series.BrandId);
}

ICarService carService = new CarManager(new EfCarDal());

List<Car> cars = carService.GetCarsByBrandId(2); // 2 => Toyota
PrintCars(cars);


/*  InMemory data access testing
 * 
RentACarProDbContext db = new RentACarProDbContext();
foreach (var car in db.Cars)
{
    Console.WriteLine(car.Id);
}
Console.WriteLine("--------");

ICarDal _carDal = new InMemoryCarDal();

PrintCars(_carDal.GetAll());

_carDal.Add(new Car { Description = "New Car!" }); // work properly
//_carDal.Add(null); // throws and exception { Value cannot be null. (Parameter 'car') }

PrintCars(_carDal.GetAll());

_carDal.Update(new Car { Id = 1, Description = "Updated Desc"}); // update exist ones
//_carDal.Update(new Car { Id = -20, Description = "Will not work" }); // throws an exception { 'Sequence contains no matching element' }

PrintCars(_carDal.GetAll());

_carDal.Delete(new Car { Id = 2 }); // delete exist ones
//_carDal.Delete(new Car { Id = -20 }); // throws an exception { 'Sequence contains no matching element' }

PrintCars(_carDal.GetAll());

Console.WriteLine(_carDal.Get(c => c.Id == 3).Description); // return first element that satisfy the condition
//Console.WriteLine(_carDal.Get(c => c.Id == -22).Description); // throws an exception { 'Sequence contains no matching element' }

PrintCars(_carDal.GetAll(c => c.Id < 3)); // return elements that satisfy the condition
PrintCars(_carDal.GetAll(c => c.Id < -1)); // return empty list
*/

#region Local Functions

static void PrintCar(Car car)
{
    Console.WriteLine("{0} - {1} AZN [{2}] | {3}", car.Id, car.DailyPrice, car.BrandId, car.Description[..40]);
}

static void PrintCars(List<Car> cars)
{
    foreach (var car in cars)
    {
        PrintCar(car);
    }
    Console.WriteLine();
}

#endregion