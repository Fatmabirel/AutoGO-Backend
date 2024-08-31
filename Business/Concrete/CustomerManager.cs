using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            var customerToDelete = _customerDal.Get(c => c.UserId == customer.UserId);
            if (customerToDelete == null)
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }
            
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var customers = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customers, Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var customer = _customerDal.Get(c => c.Id == customerId);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            
            return new SuccessDataResult<Customer>(customer);
        }

        public IResult Update(Customer customer)
        {
            var customerToUpdate = _customerDal.Get(c => c.Id == customer.Id);
            if (customerToUpdate == null)
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }
            
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
