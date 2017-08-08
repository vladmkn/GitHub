using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostponeControllerTest.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Task : BaseObject
    {
        public Task(Session session) : base(session) { }
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue<string>("Description", value); }
        }
        public DateTime DueDate
        {
            get { return GetPropertyValue<DateTime>("DueDate"); }
            set { SetPropertyValue<DateTime>("DueDate", value); }
        }
    }
}
