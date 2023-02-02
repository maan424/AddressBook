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
        private List<ListAddressBook> participants;

        //CONSTRUCTOR
        public AddressBookManager()
        {

            participants = new List<ListAddressBook>();
            //TestValues();
        }
        //NO PROPERTIES
        /// <summary>
        /// Get value of a participant when change is required.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>participants[index]</returns>
        public ListAddressBook GetParticipantAt(int index)
        {
            if (index < 0 || index >= participants.Count)
                return null;
            return participants[index];
        }
        /// <summary>
        /// counting of participants
        /// </summary>
        public int Count
        {
            get { return participants.Count; }
        }
        /// <summary>
        /// Add a participant to the list.
        /// </summary>
        /// <returns>bool</returns>
        public bool AddParticipant(string firstName, string lastName, Address addressIn)
        {
            ListAddressBook Participant = new ListAddressBook(firstName, lastName, addressIn);
            participants.Add(Participant);
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
            participants.Add(ParticipantIn);
            return true;
        }
        /// <summary>
        /// to change a participant of the list.
        /// </summary>
        /// <param name="ParticipantIn"></param>
        /// <param name="index"></param>
        /// <returns>ok</returns>
        public bool ChanngeParticipantAt(ListAddressBook ParticipantIn, int index)
        {
            bool ok = true;
            if ((ParticipantIn != null) && (CheckIndex(index)))
                participants[index] = ParticipantIn;
            else
                ok = false;
            return ok;
        }
        /// <summary>
        /// check how mant participant is in the list.
        /// to remove a clicked participant.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < participants.Count);
        }
        public bool DeleteParticipantAt(int index)
        {
            if (CheckIndex(index))
                participants.RemoveAt(index);
            else
                return false;
            return true;
        }
        /// <summary>
        /// convert format of participant to a string.
        /// </summary>
        /// <returns>strInfoStrings</returns>
        public string[] GetParticipantInfo()
        {
            string[] strInfoStrings = new string[participants.Count];
            int i = 0;
            foreach (ListAddressBook participantObj in participants)
            {
                strInfoStrings[i++] = participantObj.ToString();
            }
            return strInfoStrings;
        }

    }
}
