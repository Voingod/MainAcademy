using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CSharp_Net_module2_1_2_lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 15) Declare objects DataSet, DataAdapter and others
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        //DESKTOP-MEE5AH6\SQLEXPRESS(DESKTOP-MEE5AH6\voing)
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=University;Integrated Security=True";
        
        string sql = "SELECT FirstName,SecondName,Email,PhoneNumber,DepartmentName AS Department " +
            "FROM Students INNER JOIN Departments ON Students.DepartmentID = Departments.ID " +
            "WHERE SecondName IS NOT NULL AND Email IS NOT NULL";




        public MainWindow()
        {
           
            InitializeComponent();
            #region DatatableHandInit
            DataTable table = new DataTable("Students");
            DataRow row;
            table.Columns.Add(new DataColumn("ID"));
            table.Columns.Add(new DataColumn("FirstName"));
            table.Columns.Add(new DataColumn("LastName"));
            table.Columns.Add(new DataColumn("Phone"));

            Random random = new Random(); 

            for (int i = 0; i <= 2; i++)
            {
                var rnd = random.Next(1000000, 9999999);
                row = table.NewRow();
                row["ID"] = i;
                row["FirstName"] = "Petro " + i;
                row["LastName"] = "Vaskin  " + i;
                row["Phone"] = rnd;
                table.Rows.Add(row);
            }

            //DataSet dataSet = new DataSet();
            //dataSet.Tables.Add(table);
            #endregion

            // 9) Set Background for button; use Brushes
            btnShowOtherWindow.Background = Brushes.BlueViolet;


            // 16) Set DataAdapter and DataSet
            // Note: Don't forget to use connection string

            // 17) Add datacontext of datagrid with code:
            // dataGridView.DataContext = da.Tables[“MyTable"];
            // Where 
            // dataGridView – name (object) of used datagrind
            // da – object of DataSet
            // “MyTable” – table name
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter.SelectCommand = new SqlCommand(sql, connection);
                adapter.Fill(dataSet);
            }
            dgStudents.DataContext = dataSet.Tables[0];
        }

        private void btnShowOtherWindow_Click(object sender, RoutedEventArgs e)
        {
            Pictures pictures = new Pictures();
            pictures.ShowDialog();
        }


        // 11) Add event handler on button click (for colored button)

        // 12) Add new window to project
        // In new window add XAML to show backgroud image

        // 13) invoke method ShowDialig() for new window


        // 18) Add event handler on button click (for 2nd button)

        // 19) invoke method Update() of DataAdapter to update data

    }
}
