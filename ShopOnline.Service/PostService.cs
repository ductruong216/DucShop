using ShopOnline.Model.Models;
using System.Collections.Generic;
using System;
using ShopOnline.Data.Parttern;
using ShopOnline.Data.Repositories;

namespace ShopOnline.Service
{
    public interface IPostService
    {
        void AddPost(Post post);

        void UpdatePost(Post post);

        void DeletePostById(int id);

        IEnumerable<Post> GetAllPost();

        IEnumerable<Post> GetAllPostPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetAllPostByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GetAllPostByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddPost(Post post)
        {
            _postRepository.Add(post);
        }

        public void DeletePostById(int id)
        {
            _postRepository.DeleteById(id);
        }

        public IEnumerable<Post> GetAllPost()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" }); 
        }

        public IEnumerable<Post> GetAllPostByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPostByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Select all post by Tag
            return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPostPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x=>x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
             _unitOfWork.Commit();
        }

        public void UpdatePost(Post post)
        {
            _postRepository.Update(post);
        }
    }
}