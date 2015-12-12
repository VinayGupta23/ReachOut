using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace ReachOut.DataModel
{
    [ParseClassName("Authorizer")]
    public class Authorizer : ParseObject
    {
        [ParseFieldName("name")]
        public string name
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
    }
}
