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
         [ParseFieldName("area")]
         public string area
         {
             get { return GetProperty<string>(); }
             set { SetProperty<string>(value); }
         }
         [ParseFieldName("status")]
         public bool status
         {
             get { return status; }
             set { this.status = value; }
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
         public ParseGeoPoint  location
         {
             get { return GetProperty<ParseGeoPoint>(); }
             set { SetProperty<ParseGeoPoint>(value); }
         } 

    }
}
