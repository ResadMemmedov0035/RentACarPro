using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ItemRecieved);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult? errorResult = BusinessRule.Run(
                () => CheckIfCarHasRented(rental.CarId));

            if (errorResult != null) return errorResult;

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddSuccess);
        }

        private IResult CheckIfCarHasRented(int carId)
        {
            var rentals = _rentalDal.GetAll();

            if (rentals.Count != 0 && rentals.Where(r => r.CarId == carId && r.ReturnDate == null).Any())
            {
                return new ErrorResult("The car you want to rent has been rented");
            }
            return new SuccessResult();
        }
    }
}
