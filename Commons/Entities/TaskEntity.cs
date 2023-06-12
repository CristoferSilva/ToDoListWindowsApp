using Commons.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Entities
{
    public abstract class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        private bool isChecked;
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public bool IsChecked
        {
            get { return isChecked; }
            set { if (isChecked != value) { isChecked = value; NotifyDB(); } }
        }

        public async void NotifyDB()
        {
            await RespositoryService.RemoveTaskAsync(this);
            await RespositoryService.AddNewTaskInDataBase(this);
        }

        [NotMapped]
        public ITaskRespositoryService RespositoryService { get; set; }



    }

}
