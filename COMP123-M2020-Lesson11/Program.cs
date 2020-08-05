using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_M2020_Lesson11
{
    public static class Program
    {
        public static List<Contact> contacts;

        public static DBViewForm dbViewForm;

        public static ContactinfoForm contactinfoForm;
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            contacts = new List<Contact>(); // new empty list of contacts
            dbViewForm = new DBViewForm();
            contactinfoForm = new ContactinfoForm();

            Application.Run(dbViewForm);
        }
    }
}
