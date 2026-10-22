using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Entities
{
    abstract class BaseEntity
    {
        protected readonly int id = 0;
        static int autoInc = 1;
        protected string name = "";

        public BaseEntity(string name)
        {
            this.name = name;
            this.id = autoInc++;
        }

        public int GetId() => this.id;
        public string GetName() => this.name;
    }
}
