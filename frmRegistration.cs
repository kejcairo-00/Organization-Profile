using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }
       

        private string FullName(string lastName, string firstName, string middleInitial)
        {
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleInitial))
            {
                throw new ArgumentNullException("Full name cannot be empty.");
            }
            else
            {
                return lastName + ", " + firstName + " " + middleInitial;
            }
        }

        private int StudentNumber(string studentNo)
        {
            if (string.IsNullOrEmpty(studentNo))
            {
                throw new ArgumentNullException("Student number cannot be empty.");
            }
            else
            {
                try
                {
                    return int.Parse(studentNo);
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Invalid student number format.", ex);
                }
                catch (OverflowException ex)
                {
                    throw new OverflowException("Student number is too large.", ex);
                }
            }
            
        }

        private long ContactNo(string contactNo)
        {
            if (string.IsNullOrEmpty(contactNo))
            {
                throw new ArgumentNullException("Contact number cannot be empty.");
            }
            else
            {
                try
                {
                    return long.Parse(contactNo);
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Invalid contact number format.", ex);
                }
                catch (OverflowException ex)
                {
                    throw new OverflowException("Contact number is too large.", ex);
                }
            }
        }

        private int Age(string age)
        {
            if (string.IsNullOrEmpty(age))
            {
                throw new ArgumentNullException("Age cannot be empty.");
            }
            else
            {
                try
                {
                    return int.Parse(age);
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Invalid age format.", ex);
                }
                catch (OverflowException ex)
                {
                    throw new OverflowException("Age is too large.", ex);
                }
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            try
            {
                _FullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                _StudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetStudentNo = (int)_StudentNo;

                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                _ContactNo = ContactNo(txtContactNo.Text);
                _Age = Age(txtAge.Text);
                StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                StudentInformationClass.SetFullName = _FullName;
                StudentInformationClass.SetStudentNo = (int)_StudentNo;
                StudentInformationClass.SetContactNo = _ContactNo;
                StudentInformationClass.SetAge = _Age;

                confirmationForm frm = new confirmationForm();
                frm.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid format: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Null or empty value: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow error: " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Index out of range: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}