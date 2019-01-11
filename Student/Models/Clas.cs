using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models
{
   public class Clas
    {
        public int ClasId { get; set; }
        public string ClasName { get; set; }
        //导航属性，目的是能够通过博客对象访问对应的一组贴子
        public virtual List<Stu> Student { get; set; }

    }
}
