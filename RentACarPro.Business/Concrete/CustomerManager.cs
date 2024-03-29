﻿using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.AllRecieved);
        }

        public IDataResult<Customer> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.ItemRecieved);
            }
            catch (EntityNotFoundException<Customer> e)
            {
                return new ErrorDataResult<Customer>(e.Message);
            }
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddSuccess);
        }
    }
}
