using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace ReachOut.DataModel
{
    [ParseClassName("User")]
    public class User : ParseObject
    {
        [ParseFieldName("username")]
        public string userName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("email")]
        public string email
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("password")]
        public string password
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("address")]
        public string address
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
    }
}

