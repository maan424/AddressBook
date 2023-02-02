using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ListAddressBookManager
    {

        private string title;
        AddressBookManager AddressBookManager = new AddressBookManager();
        //constructor
        public ListAddressBookManager()
        {
            AddressBookManager = new AddressBookManager();
        }
        #region PROPERTIES
        /// <summary>
        /// Readonly property but still sending the ref of
        /// the object. participantmanager should not have all its members
        /// accessable publicly. 
        /// </summary>

        public AddressBookManager Participants
        {
            get { return AddressBookManager; }
        }
        /// <summary>
        /// get/set method to title
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    title = value;
            }
        }

        #endregion
    }
}
