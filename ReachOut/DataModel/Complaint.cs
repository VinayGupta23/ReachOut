using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;


namespace ReachOut.DataModel
{
    [ParseClassName("Complaint")]
    public class Complaint : ParseObject
    {
        [ParseFieldName("title")]
        public string title
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("description")]
        public string description
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("status")]
        public string status
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("heatCount")]
        public string heatCount
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("registrantId")]
        public string registrantId
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("location")]
        public ParseGeoPoint location
        {
            get { return GetProperty<ParseGeoPoint>(); }
            set { SetProperty<ParseGeoPoint>(value); }
        }
        [ParseFieldName("category")]
        public string category
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        [ParseFieldName("authorizerId")]
        public string authorizerId
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
    }
}
