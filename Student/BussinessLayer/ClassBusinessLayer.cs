using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Student.Models;
using Student.DataAccessLayer;

namespace Student.BussinessLayer
{
    public class ClassBusinessLayer
    {
        public void Add(Clas clas)
        {
            //设置上下文生存期
            using (var db = new ClassContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Clas.Add(clas);
                //db.Entry(Blog).State = EntityState.Added;
                //保存状态改变
                db.SaveChanges();
            }
        }

        public List<Clas> Query()
        {
            using (var db = new ClassContext())
            {
                return db.Clas.ToList();

            }
        }

        //根据ID查询
        public Clas Query(int id)
        {
            //使用上下文对象
            using (var db = new ClassContext())
            {
                //调用Find(id)返回Blogs
                return db.Clas.Find(id);
            }
        }

        public void Update(Clas clas)
        {
            //设置上下文生存期
            using (var db = new ClassContext())
            {
                //用枚举来表示修改状态
                db.Entry(clas).State = EntityState.Modified;
                //保存状态改变
                db.SaveChanges();
            }
        }

        //根据ID删除
        public void Delete(Clas clas)
        {
            using (var db = new ClassContext())
            {
                //修改博客实体状态
                db.Entry(clas).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }


    }
}
