using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace Contacts.WebAPI.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/contacts/{0}", this.ContactId);
            }
            set { }
        }
    }
}