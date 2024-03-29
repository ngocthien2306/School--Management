﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management.Manager.Contact
{
    public partial class Add_Contacts : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Add_Contacts()
        {
            InitializeComponent();

        }

        private void Add_Contacts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'manager_StudentDataSet1.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter.Fill(this.manager_StudentDataSet1.Contact);
            Group group = new Group();
            My_Database data = new My_Database();
            SqlCommand command = new SqlCommand("SELECT GRoup_id, Group_name FROM Group1", data.GetConnection);
            DataTable table;
            table = group.GetGroup(command);
            foreach (DataRow row in table.Rows)
            {
                ComboBox_GroupID.Items.Add(row[1].ToString().Trim());

            }
            DateEdit_Birthday.Text = "1/1/2000";
        }

        private void BarButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Contact_class contact = new Contact_class();
            try
            {
                int user_id = Convert.ToInt32(TextEdit_ID.Text);
                string firstname = TextEdit_Fname.Text;
                string lastname = TextEdit_Lastname.Text;
                DateTime bday = DateEdit_Birthday.DateTime;
                string gender = ComboBoxEdit_Gender.SelectedText.ToString();
                string groupid = ComboBox_GroupID.SelectedText.ToString();
                string address = TextEdit_Address.Text;
                string city = TextEdit_City.Text;
                int phone =Convert.ToInt32(TextEdit_Phone.Text);
                string email = TextEdit_Mail.Text;
                string fbook = TextEdit_Fb.Text;
                MemoryStream pic = new MemoryStream();
                PictureEdit_User.Image.Save(pic, PictureEdit_User.Image.RawFormat);
                if(contact.InsertContact(firstname, lastname, groupid, gender, bday, phone, email, fbook, address, city, pic, user_id))
                {
                    XtraMessageBox.Show("Add contact successful!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Add contact failed!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            catch
            {
                XtraMessageBox.Show("The control textbox are blank, please enter again!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void PictureEdit_User_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.pnq;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                PictureEdit_User.Image = Image.FromFile(open.FileName);
            }
        }

        private void contactBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contactBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.manager_StudentDataSet1);

        }
    }
}