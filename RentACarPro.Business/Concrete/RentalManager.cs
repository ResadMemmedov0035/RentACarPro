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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ItemRecieved);
        }

        public IResult AddRental(Rental rental)
        {
            var rentals = _rentalDal.GetAll();

            if (rentals.Count != 0 && rentals.Any(r => r.CarId == rental.CarId && r.ReturnDate == null))
            {
                return new ErrorResult("The car you want to rent has been rented");
            }

            try
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.AddSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
