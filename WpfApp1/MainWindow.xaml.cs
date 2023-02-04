using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
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
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Collections;
using System.Security.Cryptography.Xml;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1

{
    /// <summary>
    /// One Class to Read and Count cost and fee and initial and update them to a new party.
    /// Even validate if inputs are valid.
    /// </summary>

    public partial class MainWindow : Window
    {
        ListAddressBookManager ListAddressBookManager;
        public MainWindow()
        {
            InitializeComponent();
            InitialzeGUI();

         
        }

    
    /// <summary>
    /// Initial a value to each texbox.
    /// Set groupbox1 till True , it means that we can creat a new event.
    /// </summary>
    private void InitialzeGUI()
        {
            
            comboBox1.ItemsSource = Enum.GetNames(typeof(Countries));
            comboBox1.SelectedIndex = (int)Countries.Sweden;
            //Clear output controls

            listBox1.Items.Clear();
            //Enable the create new Event groupbox.

            ListAddressBookManager = new ListAddressBookManager();
        }

        /// <summary>
        /// This method upgate every inputs boxes and count total  cost and fee.
        /// </summary>
        private void UppdateGUI()
        {
          
            string[] strInfo = ListAddressBookManager.ListAddressBook.GetParticipantInfo();
            string json = JsonSerializer.Serialize(strInfo);
           

          


            if (strInfo != null)
            {               
                listBox1.ItemsSource = strInfo;
                string[] result = strInfo[0].Split(" ");

                // using the method
               

                foreach (string s in result)
                {
                    File.WriteAllText("C:\\Users\\maxnf\\Desktop\\WpfApp1\\path.json", s);
                }

            }
        }
        /// <summary>
        /// This button init a new  calss and update method uppdate()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {



            ListAddressBook ListAddressBook = new ListAddressBook();
            if (ReadInput(ref ListAddressBook))
            {

         
            UppdateGUI();
            }
        }
        /// <summary>
        /// Validate method to set correct amount and value to every inputs box. 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool validareText(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please provide both the first name and second name");
                return false;
            }
            return true;
        }
        /// <summary>
        /// call one method to validate inputs
        /// </summary>
        /// <param name=" ListAddressBook"></param>
        /// <returns>ok</returns>
        private bool ReadInput(ref ListAddressBook participant)
        {
            bool ok = ReadParticipantData(ref participant);
            if (ok)
            {

                ListAddressBookManager.ListAddressBook.AddParticipant(participant);

            }
            else
            {
                string strMessage = "First,Second name and city is required";
                MessageBox.Show(strMessage);
            }
            return ok;
        }
        /// <summary>
        ///  Read first name, second name and adress and sent en bool value to validator.
        /// </summary>
        /// <param name=" ListAddressBook"></param>
        /// <returns>ok</returns>
        private bool ReadParticipantData(ref ListAddressBook ListAddressBook)
        {
            ListAddressBook.FirstName = textBox4.Text;
            ListAddressBook.LastName = textBox5.Text;
            Address address = ReadAddress();
            ListAddressBook.Address = address;
            bool ok = address.Validate();

            return ok;
        }
        /// <summary>
        /// Get address and add country to it.
        /// </summary>
        /// <returns>address</returns>
        private Address ReadAddress()
        {
            Address address = new Address();
            address.Email = textBox6.Text;
            address.Telephone = textBox8.Text;
            address.City = textBox7.Text;

            address.Country = (Countries)comboBox1.SelectedIndex;
            return address;
        }
        /// <summary>
        /// change button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button3_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            /*  textBox1.Text = index.ToString();*/
            if (index < 0)
                return;
            ListAddressBook ListAddressBook = ListAddressBookManager.ListAddressBook.GetParticipantAt(index);
            if (ReadParticipantData(ref ListAddressBook))
            {
                ListAddressBookManager.ListAddressBook.ChanngeParticipantAt(ListAddressBook, index);
                UppdateGUI();
            }
        }
        /// <summary>
        /// delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if (index < 0)
                return;
            ListAddressBookManager.ListAddressBook.DeleteParticipantAt(index);
            UppdateGUI();
        }
        /// <summary>
        /// set every boxes to new value efter changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox1.SelectedIndex;

            if (index >= 0)
            {
                ListAddressBook ListAddressBook = ListAddressBookManager.ListAddressBook.GetParticipantAt(index);

                textBox4.Text = ListAddressBook.FirstName;
                textBox5.Text = ListAddressBook.LastName;
                textBox6.Text = ListAddressBook.Address.Email;
                textBox7.Text = ListAddressBook.Address.City;
                textBox8.Text = ListAddressBook.Address.Telephone;
                comboBox1.SelectedIndex = (int)ListAddressBook.Address.Country;

            }
            else
            {
                MessageBox.Show("Select an item.");
            }
        }    

    }
}

