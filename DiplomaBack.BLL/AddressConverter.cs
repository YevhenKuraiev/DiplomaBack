using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DiplomaBack.BLL.BusinessModels;
using GoogleMapsAPI.NET.API.Client;

namespace DiplomaBack.BLL
{
    public class AddressConverter
    {
        private static readonly MapsAPIClient Client = new MapsAPIClient("AIzaSyBP1XG4Z5nph35aVskXQuhBmESwZc3_JXU");
        public List<AddressCoordinates> AddressToCoordinates(List<string> addresses)
        {
            var addressCoordinatesList = new List<AddressCoordinates>();
            foreach (string adress in addresses)
            {
                var response = Client.Geocoding.Geocode(adress);
                var addressCoordinates = new AddressCoordinates
                {
                    //Address = adress,
                    Latitude = response.Results.FirstOrDefault()?.Geometry.Location.Latitude,
                    Longitude = response.Results.FirstOrDefault()?.Geometry.Location.Longitude,
                };
                addressCoordinatesList.Add(addressCoordinates);
            }
            return addressCoordinatesList;
        }
    }
}
