using Building.Manager.Controls.Schedule;
using Building.Manager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Building.Manager.Extensions;
using Building.Manager.Models;
using Task = Building.Manager.Model.Task;
using BuisinessLayer;

namespace Building.Manager.Controls
{
    
    public partial class SheduleControl : UserControl
    {
        private ScheduleViewModel _scheduleDataContext;
        public SheduleControl()
        {
            _scheduleDataContext = new ScheduleViewModel();
            _scheduleDataContext.Tasks = new ObservableCollection<Task>();
            _scheduleDataContext.NewTask = new Task() { DateStart = DateTime.Now, DateEnd = DateTime.Now};
            _scheduleDataContext.SaveCommand = new SaveCommand(SaveSchedule);
            _scheduleDataContext.DeleteCommand = new DeleteCommand(DeleteTask);
            

            InitializeComponent();
            this.DataContext = _scheduleDataContext;

        }
               
 
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindTasks();
        }


        public void DeleteTask(Task task)
        {
             
            Task deletetask = (Task)taskList.SelectedItem;
            Services.DeleteTask(deletetask);
            MessageBox.Show("Записът е изтрит");
            BindTasks();

        }

        public void SaveSchedule(Task task)
        {
            Task tasks = new Task();
            tasks.TaskName = Box_TaskName.Text;
            tasks.DateStart = Date1.SelectedDate.Value;
            tasks.DateEnd = Date2.SelectedDate.Value;
            Services.SaveTask(tasks);
            MessageBox.Show("Успешно добавен запис!");
            BindTasks();

        }

        private void BindTasks()
        {
            var tasks = new List<Task>();
            using (var db = new BM_DatabaseEntities())
            {
                tasks  = db.Tasks.ToList();
            }

            _scheduleDataContext.Tasks.Clear();
            tasks.ForEach(task =>_scheduleDataContext.Tasks.Add(task));
            taskList.ItemsSource = tasks;
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TaskList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

