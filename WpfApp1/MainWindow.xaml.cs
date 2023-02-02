using System;
using System.Collections.Generic;
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

namespace WpfApp1

{
    /// <summary>
    /// One Class to Read and Count cost and fee and initial and update them to a new party.
    /// Even validate if inputs are valid.
    /// </summary>

    public partial class MainWindow : Window
    {
        ListAddressBookManager eventManager;
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
           
            eventManager = new ListAddressBookManager();
        }




        /// <summary>
        /// This method upgate every inputs boxes and count total  cost and fee.
        /// </summary>
        private void UppdateGUI()
        {
          
            string[] strInfo = eventManager.Participants.GetParticipantInfo();
            if (strInfo != null)
            {
 
                listBox1.ItemsSource = strInfo;


            }


        }
        /// <summary>
        /// This button init a new  calss and update method uppdate()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {

            ListAddressBook participant = new ListAddressBook();
            if (ReadInput(ref participant))
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
        /// <param name="participant"></param>
        /// <returns>ok</returns>
        private bool ReadInput(ref ListAddressBook participant)
        {
            bool ok = ReadParticipantData(ref participant);
            if (ok)
            {

                eventManager.Participants.AddParticipant(participant);

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
        /// <param name="participant"></param>
        /// <returns>ok</returns>
        private bool ReadParticipantData(ref ListAddressBook participant)
        {
            participant.FirstName = textBox4.Text;
            participant.LastName = textBox5.Text;
            Address address = ReadAddress();
            participant.Address = address;
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
            ListAddressBook participant = eventManager.Participants.GetParticipantAt(index);
            if (ReadParticipantData(ref participant))
            {
                eventManager.Participants.ChanngeParticipantAt(participant, index);
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
            eventManager.Participants.DeleteParticipantAt(index);
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
                ListAddressBook participant = eventManager.Participants.GetParticipantAt(index);

                textBox4.Text = participant.FirstName;
                textBox5.Text = participant.LastName;
                textBox6.Text = participant.Address.Email;
                textBox7.Text = participant.Address.City;
                textBox8.Text = participant.Address.Telephone;
                comboBox1.SelectedIndex = (int)participant.Address.Country;

            }
            else
            {
                MessageBox.Show("Select an item.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

