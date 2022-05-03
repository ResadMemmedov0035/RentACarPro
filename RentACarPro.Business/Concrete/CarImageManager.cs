using Core.Utilities.Business;
using Core.Utilities.Helpers.FormFileHelpers;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
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
    public class CarImageManager : ICarImageService
    {
        private readonly string _defaultImage = "default.png";
        private readonly ICarImageDal _carImageDal;
        private readonly IFormFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFormImageHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var images = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (images.Count == 0) images.Add(new CarImage { ImagePath = _defaultImage });
            return new SuccessDataResult<List<CarImage>>(images);
        }

        public IResult Add(int carId, IFormFile file)
        {
            IResult? errorResult = BusinessRule.Run(
                () => CheckIfCarImageLimitExceeded(carId));

            if (errorResult != null) return errorResult;

            var carImage = new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = _fileHelper.Add(file)
            };
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult Update(int id, IFormFile file)
        {
            var image = _carImageDal.Get(ci => ci.Id == id);

            image.ImagePath = _fileHelper.Update(file, image.ImagePath);
            _carImageDal.Update(image);

            return new SuccessResult(Messages.UpdateSuccess);
        }

        public IResult Delete(int id)
        {
            var image = _carImageDal.Get(ci => ci.Id == id);

            _fileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(image);
            
            return new SuccessResult(Messages.DeleteSuccess);
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var images = _carImageDal.GetAll(ci => ci.CarId == carId);

            if (images.Count > 5)
                return new ErrorResult(Messages.CarImageLimitExceeded);

            return new SuccessResult();
        }
    }
}
