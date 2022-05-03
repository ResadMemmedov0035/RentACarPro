using RentACarPro.DataAccess.Abstract;
using RentACarPro.DataAccess.Concrete.InMemory;
using RentACarPro.DataAccess.Concrete.EntityFramework;
using RentACarPro.Entities.Concrete;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Core.Exceptions;

ICarDal dal = new EfCarDal();


//try 
//{
//    var car = dal.Get(c => c.Id == 1212); 
//}
//catch (EntityNotFoundException<Car> e)
//{
//    Console.WriteLine(e.Message);
//}

//var securityKey = .CreateSecurityKey("ultrasecretkey");
//var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

//Console.WriteLine(signingCredentials);


//HashHelper.CreatePasswordHash("qwerty123", out byte[] salt, out byte[] hash);

//Console.WriteLine(HashHelper.VerifyPasswordHash("qwerty123", salt, hash));



//File.Create(@"C:\Users\hp\Desktop\Test.jpg");
//File.Delete(@"C:\Users\hp\Desktop\Test.jpg");

//IUserService userService = new UserManager(new EfUserDal());
//userService.Add(new User { Email = "rm@mail.com" });


/*
IRentalService rentalService = new RentalManager(new EfRentalDal());

var result = rentalService.AddRental(new Rental 
{
    CustomerId = 1,
    CarId = 1,
    RentDate = DateTime.Now
});

Console.WriteLine(result.Message);
*/



/*
ICarService carService = new CarManager(new EfCarDal());

//carService.AddCar(new Car { BrandId = 3, ModelId = 9, ColorId = 1 });

foreach (var carDetail in carService.GetAllCarDetails().Data)
{
    Console.WriteLine("{0} - {1} {2} ({3}) [{6}], {4}AZN | {5}",
        carDetail.Id, carDetail.BrandName, carDetail.ModelName, carDetail.ModelYear, carDetail.DailyPrice, carDetail.Description[..25], carDetail.ColorName);
}
*/




//var efSeriesDal = new EfSeriesDal();

//efSeriesDal.Add(new Series { BrandId = 1, Name = "Five" });

//efSeriesDal.Update(new Series { Id = 15, BrandId = 1, Name = "adfsad" });

//Console.WriteLine(efSeriesDal.Get(x => x.Id == 2332));

//foreach (var item in efSeriesDal.GetAll(x => x.Id == 200)) // return empty list
//{
//    Console.WriteLine(item);
//}


//ISeriesService seriesService = new SeriesManager(new EfSeriesDal());

////seriesService.AddSeries(new Series { Name = "T", BrandId = 1 });
////seriesService.UpdateSeries(new Series { Id = 5, BrandId = 2, Name = "Test Updated" });

//foreach (var series in seriesService.GetAllSeries())
//{
//    Console.WriteLine("{0} - {1} [{2}]", series.Id, series.Name, series.BrandId);

//}

//ICarService carService = new CarManager(new EfCarDal());

//List<Car> cars = carService.GetCarsByBrandId(2); // 2 => Toyota
//PrintCars(cars);


/*  
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
//Console.WriteLine(_carDal.Get(c => c.Id == -22).Description); // return null

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