using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning
{
    class Address
    {
        /// <summary>
        /// Fiels = INSTANCE VARIABLES
        /// Input fields
        /// </summary>

        private string email;
        private string telephone;
        private string city;
        private Countries country;
        /// <summary>
        /// get/set to value street
        /// </summary>
        public string Email
        {
            get { return email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    email = value;
            }
        }
        /// <summary>
        /// get/set method to city
        /// </summary>
        public string City
        {
            get { return city; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    city = value;
            }
        }
        /// <summary>
        /// get/set method to zipcode
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    telephone = value;
            }
        }
        /// <summary>
        /// get/set method to value country.
        /// </summary>
        public Countries Country
        {
            get { return country; }
            set { country = value; }
        }

        //other Methods

        /// <summary>
        /// This function simply deletes the "_" from country
        /// </summary>
        /// <returns> The country name without underscore char </returns>
        public string GetCountryString()
        {
            string strCountry = country.ToString();
            strCountry = strCountry.Replace("_", " ");
            return strCountry;
        }
        /// <summary>
        /// Constructor with 4 parameters - used by other constructs too
        /// Strings are initiated to null by the compiler.
        /// It is better to assign then an Empty so they are no longer null
        /// </summary>
        public Address (string email, string tele, string city, Countries country)
        {
            this.email = email;
            this.telephone = tele;
            this.city = city;
            this.country = country;
        }
        /// <summary>
        /// Constructor - call the next constructor for reuse
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tele"></param>
        /// <param name="city"></param>

        public Address(string email, string tele, string city) :
            this(email, tele, city, Countries.Sweden)
        {
            /// <summary>
            ///  Default constructor calling another constructor in this class.
            /// </summary>
        }
        public Address() : this(string.Empty, string.Empty, string.Empty)
        {

        }
        /// <summary>
        /// Take if adress is not in the same format.
        /// </summary>
        /// <param name="theOther"></param>
        public Address (Address theOther)
        {
            this.email = theOther.email;
            this.telephone = theOther.telephone;

        }
        /// <summary>
        /// do some checking of data
        /// Address must have a city and country. Country is an enum
        /// an it will always have a default value.
        /// City is initiated to null so it should get validated.
        /// But it is ok if the rest is not given.
        /// </summary>
        public bool Validate()
        {
            bool cityOk = !string.IsNullOrEmpty(city);
            return cityOk;
        }
        /// <summary>
        /// Formatting text intp several lines
        /// </summary>
        public string getAddressLabal()
        {
            string strOut = email + Environment.NewLine;
            strOut += telephone + " " + city;
            return strOut;
        }
        /// <summary>
        /// to write out adress in a format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strOut = string.Format("{0,-25} {1,-8} {2,-10} {3}",
                 email, telephone, city, GetCountryString());
            return strOut;
        } //class
       

    }
}

        