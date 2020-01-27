using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Student stu = new Student()
            {
                FullName = "Bob Goobman",
                DateOfBirth = DateTime.Today
            };

            StudentDB.Add(stu);
            MessageBox.Show($"Student {stu.StudentId}added");

            List<Student> allStus = StudentDB.GetAllStudents();
            MessageBox.Show("Total stus " + allStus.Count);

            stu.FullName = "Mr. Bob";
            StudentDB.Update(stu);

            StudentDB.Delete(stu);
            allStus = StudentDB.GetAllStudents();
            MessageBox.Show("Total stus " + allStus.Count);
        }
    }
}
