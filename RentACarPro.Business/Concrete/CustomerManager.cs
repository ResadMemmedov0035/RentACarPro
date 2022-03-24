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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.AllRecieved);
        }

        public IDataResult<Customer?> GetCustomerById(int id)
        {
            var data = _customerDal.Get(c => c.Id == id);
            return new SuccessDataResult<Customer?>(data, data != null ? Messages.ItemRecieved : Messages.NullRecieved);
        }

        public IResult AddCustomer(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.AddSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
