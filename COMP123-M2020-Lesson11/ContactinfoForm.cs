using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_M2020_Lesson11
{
    public partial class ContactinfoForm : Form
    {
        public ContactinfoForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configure the open file dialog
            ContactListOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            // open the file dialog
            var openFileDialogResult = ContactListOpenFileDialog.ShowDialog();

            if (openFileDialogResult != DialogResult.Cancel)
            {
                // create a new stream reader
                StreamReader streamReader = new StreamReader(ContactListOpenFileDialog.FileName);

                // read in the list
                while (!streamReader.EndOfStream)
                {
                    streamReader.ReadLine();
                    ContactListBox.Items.Add(streamReader.ReadLine());
                    streamReader.ReadLine();
                    streamReader.ReadLine();
                }

                // cleanup
                streamReader.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ContactinfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
