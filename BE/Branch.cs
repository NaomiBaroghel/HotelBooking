using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Branch
    {
        public int? BankNumber { get; set; }
        public string BankName { get; set; }
        public int? BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();

        }

    }

}
