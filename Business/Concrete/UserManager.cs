using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        // Dependency Injection
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<User>>(result, Messages.UsersListed);
            }
            else
            {
                return new ErrorDataResult<List<User>>(Messages.UserNotFound);
            }
        }

        public IDataResult<User> GetById(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user != null)
            {
                return new SuccessDataResult<User>(user, Messages.UserUpdated);
            }
            else
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
