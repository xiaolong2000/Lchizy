using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BussinessLayer
{
  public  class PostBussinessLayer
    {
        public List<Post> Query(int blogId)
        {
            using (var db=new BloggingContext())
            {
                var Query = from b in db.Posts
                            where b.BlogId == blogId
                            select b;
                return Query.ToList();
            }
        }
        public void Add(Post post)
        {
            using (var db=new BloggingContext())
            {
                db.Entry(post).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        public void Update(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Post QueryPost(int id)
        {
            using (var db=new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
        public void DeletePost(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;

                db.SaveChanges();
            }
        }
        public List<Blog> Query(string name)
        {
            using (var db = new BloggingContext())
            {
                var query = db.Blogs;
                // 查询所有包含字符串name的博客
                var blogs = from b in db.Blogs
                            where b.Name.Contains(name)
                            select b;
                return blogs.ToList();
            }
        }

    }
}
