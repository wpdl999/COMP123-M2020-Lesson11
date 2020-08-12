using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_M2020_Lesson11
{
    public partial class DBViewForm : Form
    {
        public DBViewForm()
        {
            InitializeComponent();
        }

        private void DBViewForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lesson11DBDataSet.Contacts' table. You can move, or remove it, as needed.
           this.contactsTableAdapter.Fill(this.lesson11DBDataSet.Contacts);


            ContactsDataGridView_CellClick(sender, e as DataGridViewCellEventArgs);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configure the save file dialog
            ContactListSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            // display the savefiledialog and save the results in the saveFileDialogResult object
            var saveFileDialogResult = ContactListSaveFileDialog.ShowDialog();

            if(saveFileDialogResult != DialogResult.Cancel)
            {
                // create new stream
                StreamWriter streamWriter = new StreamWriter(ContactListSaveFileDialog.FileName);

                // write to the file

                using (var db = new ContactModel()) // Entity Framework
                {
                    var contacts = (from contact in db.Contacts
                        select contact).ToList();


                    foreach (var contact in contacts)
                    {
                        streamWriter.WriteLine(contact.FirstName);
                        streamWriter.WriteLine(contact.LastName);
                        streamWriter.WriteLine(contact.EmailAddress);
                        streamWriter.WriteLine(contact.ContactNumber);
                    }
                }

                // clean up
                streamWriter.Flush();
                streamWriter.Close();
            }
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Program.contactInfoForm.Show();
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutBoxForm.ShowDialog();
        }

        private void ContactsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Program.selectedContact.FirstName = ContactsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            Program.selectedContact.LastName = ContactsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            Program.selectedContact.EmailAddress = ContactsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            Program.selectedContact.ContactNumber = ContactsDataGridView.SelectedRows[0].Cells[3].Value.ToString();

            SelectedContactTextBox.Text = $"{Program.selectedContact.FirstName} {Program.selectedContact.LastName} {Program.selectedContact.EmailAddress} {Program.selectedContact.ContactNumber}";
        }
    }
}
