using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using CodeFirstNewDatabaseSample.BussinessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            //QueryBlog();
            //UpdatePost();
            Function();
            //DeletePost();
            //AddPost();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
           //显示指定博客的帖子列表
             DisplatPosts(blogId);
            //根据指定到博客信息创建新帖子  

            
          Console.WriteLine("请输入将要添加的帖子标题" );
          string title = Console . ReadLine();
          Console.WriteLine("请输入将要添加的帖子内容" );
          string content = Console . ReadLine();
          Post post=new Post();
          post.Title =title;
          post. Content = content;
          post. BlogId = blogId;
          PostBussinessLayer pbl = new PostBussinessLayer();
          pbl.Add(post);

          //显示指定博客的帖子列表
          DisplatPosts(blogId);
        
    }

        static void Function()
        {
            //显示所有博客
            QueryBlog();
            Console.WriteLine("--1-退出 --2-新增博客   --3-更改博客  --4-删除博客  --5-操作帖子");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                return;
            }

            else if (i == 2)
            {
                //新增博客
                createBlog();
                //显示博客列表
                QueryBlog();
                Console.Clear();
                Function();
            }
            else if (i == 3)
            {
                //更改博客
                Update();

                QueryBlog();
                Console.Clear();
                Function();
            }
            else if (i == 4)
            {
                //删除博客
                Delete();
                QueryBlog();
                Console.Clear();
                Function();
            }
            else if (i == 5)
            {
                Console.WriteLine("--1-退出 --2-新增帖子   --3-更改帖子  --4-删除帖子 ");
                Console.WriteLine("请输入操作指令");
                int p =int.Parse(Console.ReadLine());
               

                if (p == 1)
                {
                    return;
                }
                else if (p == 2)
                {
                    //新增帖子
                    AddPost();
                }
                else if (p == 3)
                {
                    //更改帖子
                    UpdatePost();

                }
                else if (p == 4)
                {
                    //删除帖子
                    DeletePost();
                }


                int blogid = GetBlogId();
                //显示指定博客的帖子列表
                DisplatPosts(blogid);

            }
            else
            {
                Console.WriteLine("无效字符");
            }
        }

        static void UpdatePost()
        {
            QueryBlog();
            int blogId = GetBlogId();
            DisplatPosts(blogId);
            Console.WriteLine("请输入要更改的帖子Id");
            int id = int.Parse(Console.ReadLine());
            PostBussinessLayer pbl = new PostBussinessLayer();
            Post post = pbl.QueryPost(id);
            Console.WriteLine("请输入新标题");
            string title = Console.ReadLine();
            Console.WriteLine("请输入新的内容");
            string content = Console.ReadLine();
            post.Title = title;
            post.Content = content;
            pbl.Update(post);
            DisplatPosts(blogId);
        }
        //删除
        static void DeletePost()
        {
            QueryBlog();
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            PostBussinessLayer pbl = new PostBussinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int blogId = int.Parse(Console.ReadLine());
            DisplatPosts(blogId);
            Console.WriteLine("请输入想要删除的帖子");
            int postId = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postId);
            pbl.DeletePost(post);
            DisplatPosts(blogId);
        }
        static int GetBlogId() {
            //提示用户输入博客ID
            Console.WriteLine("请输入id");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            //返回id          
            return id;
        }
        static void DisplatPosts(int blogId) {
            Console.WriteLine(blogId + "的帖子列表");

            List<Post> list = null;
            //根据博客ID获取博客
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                list = blog.Posts;
            }
            foreach (var item in list)
            {
                Console.WriteLine(item.BlogId + "--" + item.Title);
            }

        }

        //增加--交互

        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            bbl.Add(blog);
        }

        //显示全部博客
        static void QueryBlog()
        {
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.BlogId + " " + item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        static void Delete()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }



        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }



    }
}
