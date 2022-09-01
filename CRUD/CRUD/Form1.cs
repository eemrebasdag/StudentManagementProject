using CRUD.Context;
using CRUD.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        ProjectContext Context = new ProjectContext();


        public Form1()
        {
            InitializeComponent();
        }

        public void FillListWiew()
        {
            listView1.Items.Clear();
            ListViewItem liv;

            List<Student> studentList = Context.Students.ToList();

            foreach (var item in studentList)
            {
                liv = new ListViewItem();
                liv.Text = item.Id.ToString();
                liv.SubItems.Add(item.StudentId.ToString());
                liv.SubItems.Add(item.Fullname);
                liv.SubItems.Add(item.Gender.ToString());

                liv.Tag = item;

                listView1.Items.Add(liv);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            FillListWiew();

        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student();
            newStudent.StudentId = txtStudentID.Text;
            newStudent.Fullname = txtFullname.Text;
            newStudent.Address = txtAddress.Text;
            newStudent.Email = txtEmail.Text;
            if (radioButton1.Checked)
            {
                newStudent.Gender = ENUMS.Gender.F;
            }
            else if (radioButton2.Checked)
            {
                newStudent.Gender = ENUMS.Gender.M;
            }

            Context.Students.Add(newStudent);
            Context.SaveChanges();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Student editStudent = Context.Students.Find(selectedStudentId);

            editStudent.StudentId = txtStudentID.Text;
            editStudent.Fullname = txtFullname.Text;
            editStudent.Email = txtEmail.Text;
            editStudent.Address = txtAddress.Text;

            if (radioButton1.Checked)
            {
                editStudent.Gender = ENUMS.Gender.F;
            }
            else
            {
                editStudent.Gender = ENUMS.Gender.M;
            }

            Context.SaveChanges();


            FillListWiew();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;


        }


        int selectedStudentId;

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;

            Student selectedStudent = listView1.SelectedItems[0].Tag as Student;

            selectedStudentId = selectedStudent.Id;

            txtStudentID.Text = selectedStudent.StudentId.ToString();
            txtFullname.Text = selectedStudent.Fullname;
            txtEmail.Text = selectedStudent.Email;
            txtAddress.Text = selectedStudent.Address;

            if (selectedStudent.Gender == ENUMS.Gender.F)
            {
                radioButton1.PerformClick();
            }
            else
            {
                radioButton2.PerformClick();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student deleteStudent = Context.Students.Find(selectedStudentId);

            Context.Students.Remove(deleteStudent);

            Context.SaveChanges();

            FillListWiew();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = String.Empty;
            txtFullname.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtAddress.Text = String.Empty;
            radioButton1.Checked = true;

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int textFind = int.Parse(txtFind.Text);


            Student? findStudent = Context.Students.Find(textFind) as Student;

            listView1.Items.Clear();

            ListViewItem liv = new ListViewItem();
            liv.Text = findStudent.Id.ToString();
            liv.SubItems.Add(findStudent.StudentId.ToString());
            liv.SubItems.Add(findStudent.Fullname);
            liv.SubItems.Add(findStudent.Gender.ToString());

            liv.Tag = findStudent;

            listView1.Items.Add(liv);

        }
    }
}
