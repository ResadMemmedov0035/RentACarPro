﻿using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Exceptions;
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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var errorResult = BusinessRule.Run(
                () => CheckIfUserExists(user.Email));

            if (errorResult != null) return errorResult;

            _userDal.Add(user);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            try 
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), Messages.ItemRecieved); 
            }
            catch (EntityNotFoundException<User> e)
            {
                return new ErrorDataResult<User>(e.Message);
            }
            
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        private IResult CheckIfUserExists(string email)
        {
            return _userDal.GetAll(u => u.Email == email).Any() ?
                   new ErrorResult(Messages.UserAlreadyExists) :
                   new SuccessResult();
        }
    }
}
