using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ListAddressBook
    {
        /// <summary>
        /// Fields
        /// Instance variables
        /// things to remember - initialize strings
        /// </summary>

        private string firstName = string.Empty;
        private string lastName = "";

        //Aggregation - "has a" relation
        private Address address;

        //create the address object in the constructor
        #region CONSTRACTURS
        public ListAddressBook()
        {
            address = new Address();
        }

        /// <summary>
        /// constructor with 3 parameters
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="adr"></param>
        public ListAddressBook(string firstName, string lastName, Address adr)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            if (adr != null)
                address = adr;
            else
                address = new Address();
        }
        /// <summary>
        /// Copy constructor
        /// to the address
        /// </summary>
        public ListAddressBook(ListAddressBook theother)
        {
            this.firstName = theother.firstName;
            this.lastName = theother.lastName;
            this.address = new Address(theother.address);
        }
        #region PROPERTIES
        /// <summary>
        /// get/set methods to Address
        /// </summary>
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// Get/set methods to first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        /// <summary>
        /// get/set methods to last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        /// <summary>
        /// validate if name and address is valid.
        /// </summary>
        /// <returns></returns>
        public bool validate()
        {
            bool addOK = address.Validate();
            bool nameOK = (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName));
            return addOK && nameOK;
        }

        /// <summary>
        /// <returns> The formatted info string</returns>
        /// Format the participants first name and last name and the address
        /// Call address to get the address info!
        /// </summary>
        public override string ToString()
        {
            string strOut = string.Format("{0},{1} ****** {2}", firstName, lastName, address.ToString());
            return strOut;
        }
        #endregion

    }
}
#endregion