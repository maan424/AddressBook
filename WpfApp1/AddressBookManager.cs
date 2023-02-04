using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class AddressBookManager
    {
        //FIELDS
        private List<ListAddressBook> ListAddressBook;

        //CONSTRUCTOR
        public AddressBookManager()
        {

            ListAddressBook = new List<ListAddressBook>();
            //TestValues();
        }
        //NO PROPERTIES
        /// <summary>
        /// Get value of a  ListAddressBook when change is required.
        /// </summary>
        /// <param name="index"></param>
        /// <returns> ListAddressBook[index]</returns>
        public ListAddressBook GetParticipantAt(int index)
        {
            if (index < 0 || index >= ListAddressBook.Count)
                return null;
            return ListAddressBook[index];
        }
        /// <summary>
        /// counting of  ListAddressBooks
        /// </summary>
        public int Count
        {
            get { return ListAddressBook.Count; }
        }
        /// <summary>
        /// Add a  ListAddressBook to the list.
        /// </summary>
        /// <returns>bool</returns>
        public bool AddParticipant(string firstName, string lastName, Address addressIn)
        {
            ListAddressBook Participant = new ListAddressBook(firstName, lastName, addressIn);
            ListAddressBook.Add(Participant);
            return true;
        }
        /// <summary>
        /// Constractur
        /// </summary>
        /// <param name="ParticipantIn"></param>
        /// <returns>bool</returns>
        public bool AddParticipant(ListAddressBook ParticipantIn)
        {
            if (ParticipantIn == null)
                return false;
            ListAddressBook.Add(ParticipantIn);
            return true;
        }
        /// <summary>
        /// to change a  ListAddressBook of the list.
        /// </summary>
        /// <param name="ParticipantIn"></param>
        /// <param name="index"></param>
        /// <returns>ok</returns>
        public bool ChanngeParticipantAt(ListAddressBook ParticipantIn, int index)
        {
            bool ok = true;
            if ((ParticipantIn != null) && (CheckIndex(index)))
                ListAddressBook[index] = ParticipantIn;
            else
                ok = false;
            return ok;
        }
        /// <summary>
        /// check how many  ListAddressBook is in the list.
        /// to remove a clicked participant.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < ListAddressBook.Count);
        }
        public bool DeleteParticipantAt(int index)
        {
            if (CheckIndex(index))
                ListAddressBook.RemoveAt(index);
            else
                return false;
            return true;
        }
        /// <summary>
        /// convert format of  ListAddressBook to a string.
        /// </summary>
        /// <returns>strInfoStrings</returns>
        public string[] GetParticipantInfo()
        {
            string[] strInfoStrings = new string[ListAddressBook.Count];
            int i = 0;
            foreach (ListAddressBook participantObj in ListAddressBook)
            {
                strInfoStrings[i++] = participantObj.ToString();
            }
            return strInfoStrings;
        }

    }
}
