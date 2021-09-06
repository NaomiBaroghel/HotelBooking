using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        public string HostKey { get; set; } //TZ
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; } 
        public string MailAddress { get; set; }
        public string passwordMail { get; set; }
        public int? BankAccountNumber { get; set; }
        public Branch branch { get; set; } = new Branch();
        public bool CollectionClearance { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }



      
    }

}
