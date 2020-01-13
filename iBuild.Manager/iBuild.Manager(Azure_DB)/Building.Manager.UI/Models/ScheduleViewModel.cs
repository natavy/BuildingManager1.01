using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Building.Manager.Annotations;
using Building.Manager.Model;

namespace Building.Manager.Models
{
    public class ScheduleViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public Task NewTask { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
