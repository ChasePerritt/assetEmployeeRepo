using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

/* Name: Chase Perritt
 * Date: 6 February 2020
 * File: MainWindow.xaml.cs
 * Description: This is the .cs file that implements the operations of the MainWindow.xaml file
 */
namespace AssetManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = .\LinkedEmployeesAssets.accdb");
            // LinkedEmployeesAssetsDataSet:     Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LinkedEmployeesAssets.accdb
            // LinkedEmployeesAssetsDataSet1:    Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\LinkedEmployeesAssets.accdb
            // The one that works:               Provider = Microsoft.ACE.OLEDB.12.0; Data Source = .\LinkedEmployeesAssets.accdb
        }

        private void SeeAssetsButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "    " + read[1].ToString() + "    " + read[2].ToString() + "\n";
                // Outputs all three fields (ID, AssetName, and Description)
            }
            TextView.Text = data;
            cn.Close();
        }

        private void SeeEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "    " + read[1].ToString() + "    " + read[2].ToString() + "\n";
                // Outputs all three fields (ID, First Name, and Last Name)
            }
            TextView.Text = data;
            cn.Close();
        }
    }
}
