using ShopOnline.Data.Parttern;
using ShopOnline.Data.Repositories;
using ShopOnline.Model.Models;
using System.Collections.Generic;
using System;

namespace ShopOnline.Service
{

    public interface IPostCategoryService
    {
        void AddPostCategory(PostCategory postCategory);
        void UpdatePostCategory(PostCategory postCategory);
        void DeletePostCategoryById(int id);
        PostCategory GetById(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentId);
    }
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddPostCategory(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        public void DeletePostCategoryById(int id)
        {
            _postCategoryRepository.DeleteById(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }
        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }


        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void UpdatePostCategory(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}