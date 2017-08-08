using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using PostponeControllerTest.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostponeControllerTest.Module.Controllers
{
    public partial class PostponeController : ViewController
    {
        private SimpleAction postpone;
        public PostponeController()
        {
            TargetObjectType = typeof(Task);
            postpone = new SimpleAction(this, "Postpone", "Edit");
            postpone.Execute += new SimpleActionExecuteEventHandler(Postpone_Execute);
        }
        void Postpone_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (object selectedObject in View.SelectedObjects)
            {
                Task selectedTask = (Task)selectedObject;
                if (selectedTask.DueDate == DateTime.MinValue)
                {
                    selectedTask.DueDate = DateTime.Today;
                }
                selectedTask.DueDate = selectedTask.DueDate.AddDays(1);
            }
        }
        public SimpleAction Postpone
        {
            get { return postpone; }
        }
    }
}
