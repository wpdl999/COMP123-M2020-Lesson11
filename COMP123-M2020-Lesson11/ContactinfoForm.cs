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
    public partial class ContactInfoForm : Form
    {
        public List<Contact> Contacts { get; set; }


        public ContactInfoForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configure the open file dialog
            ContactListOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            // open the file dialog
            var openFileDialogResult = ContactListOpenFileDialog.ShowDialog();

            if(openFileDialogResult != DialogResult.Cancel)
            {
                // create a new stream reader
                StreamReader streamReader = new StreamReader(ContactListOpenFileDialog.FileName);

                Contacts = new List<Contact>(); // instantiates a new the List container

                // clear content from TextBoxes
                ResetForm();

                // read in the list from the file
                while (!streamReader.EndOfStream)
                {
                    var contact = new Contact();

                    contact.FirstName = streamReader.ReadLine();
                    contact.LastName = streamReader.ReadLine();
                    contact.EmailAddress = streamReader.ReadLine();
                    contact.ContactNumber = streamReader.ReadLine();

                    ContactComboBox.Items.Add(contact.LastName);

                    Contacts.Add(contact); // add our new contact to the Contacts List
                }

                // cleanup
                streamReader.Close();

                ContactComboBox.SelectedIndex = 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ContactInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ContactComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstNameTextBox.Text = Contacts[ContactComboBox.SelectedIndex].FirstName;
            LastNameTextBox.Text = Contacts[ContactComboBox.SelectedIndex].LastName;
            EmailAddressTextBox.Text = Contacts[ContactComboBox.SelectedIndex].EmailAddress;
            ContactNumberTextBox.Text = Contacts[ContactComboBox.SelectedIndex].ContactNumber;
        }

        private void ReselectButton_Click(object sender, EventArgs e)
        {
            Program.dbViewForm.Show();
            this.Hide();
        }

        private void ContactInfoForm_Activated(object sender, EventArgs e)
        {
            // clear content from TextBoxes
            ResetForm();

            Contacts = new List<Contact>(); // instantiates a new the List container

            // Add a new contact to the Contact ComboBox List
            ContactComboBox.Items.Add(Program.selectedContact.LastName);
            Contacts.Add(Program.selectedContact);
            ContactComboBox.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            EmailAddressTextBox.Clear();
            ContactNumberTextBox.Clear();

            // clear Contact ComboBox List Items
            ContactComboBox.Items.Clear();
        }
    }
}
