using System;
using System.Collections.Generic;
using System.Text;

namespace Esoft
{
    public class Client
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }


        public override string ToString()
        {
            return $"{id} - {lastName} - {firstName} - {middleName}";
        }
    }
}
