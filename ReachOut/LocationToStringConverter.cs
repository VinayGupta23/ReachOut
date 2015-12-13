using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Parse;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;


namespace ReachOut
{
    class LocationToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ParseGeoPoint g = (ParseGeoPoint)value;
            MapLocationFinderResult result = MapLocationFinder.FindLocationsAtAsync(
                new Geopoint(new BasicGeoposition() { Latitude = g.Latitude, Longitude = g.Longitude })).GetResults();
            try
            {
                return result.Locations[0].Address;
            }
            catch
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
