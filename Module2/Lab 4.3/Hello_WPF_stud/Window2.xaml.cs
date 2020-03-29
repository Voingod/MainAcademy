using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Hello_WPF_stud
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public static readonly DependencyProperty StudentsProperty =
            DependencyProperty.Register("Students", typeof(ObservableCollection<Student>),
                typeof(Window2), new PropertyMetadata(null));

        public static readonly DependencyProperty DeleteCommandProperty =
             DependencyProperty.Register("DeleteCommand", typeof(ICommand),
                typeof(Window2), new PropertyMetadata(null));

        public ObservableCollection<Student> Students
        {
            get { return (ObservableCollection<Student>)GetValue(StudentsProperty); }
            set { SetValue(StudentsProperty, value); }
        }

        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
        public Window2()
        {
            InitializeComponent();
            Students = Student.GetStudents();
            DeleteCommand = new MyCommand() { Collection = Students };
        }

        private void StudentBG_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count == 0) return;
            var currentCell = e.AddedCells[0];
            if (currentCell.Column == StudentBG.Columns[1])
            {
                StudentBG.BeginEdit();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            string mylist = null;

            foreach (var item in Students)
            {
                mylist += item.Name.ToString() + " " + item.Rate.ToString();
                mylist += "\r\n";
            }

            MessageBox.Show(mylist);
        }
    }
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ObservableCollection<Student> Collection { get; set; }

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => Collection.Remove(parameter as Student);
    }
}
