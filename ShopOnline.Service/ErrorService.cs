using System;
using ShopOnline.Model.Models;
using ShopOnline.Data.Repositories;
using ShopOnline.Data.Parttern;

namespace ShopOnline.Service
{
    public interface IErrorService 
    {
        void Create(Error error);
        void Save();
    }

    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }
        public void Create(Error error)
        {
             _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}