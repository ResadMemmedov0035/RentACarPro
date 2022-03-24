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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.AllRecieved);
        }

        public IDataResult<User?> GetUserById(int id)
        {
            var data = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User?>(data, data != null ? Messages.ItemRecieved : Messages.NullRecieved);
        }

        public IResult AddUser(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.AddSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
