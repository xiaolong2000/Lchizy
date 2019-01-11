using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models
{
   public class Stu
    {
        public int StuId { get; set; }
        public string StuName { get; set; }
        
        //相当于数据库外码（外键）
        public int ClasId { get; set; }
        //导航属性--目的是能够通过贴子对象访问对应的博客
        public virtual Clas Clas { get; set; }
    }
}
