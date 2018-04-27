using System;
using System.Collections.Generic;
using DiplomaBack.BLL.BusinessModels;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace DiplomaBack.BLL
{
    public class DistanceBuilder
    {
        private static readonly MapsAPIClient Client = new MapsAPIClient("AIzaSyBP1XG4Z5nph35aVskXQuhBmESwZc3_JXU");

        public List<RouteInfo> GetRoutesWithDistance(List<Route> routes)
        {
            var routesWithDistance = new List<RouteInfo>();
            foreach (var route in routes)
            {
                //var resul = _client.DistanceMatrix.GetDistanceMatrix
                //(new AddressLocation("ул. Чкалова, 1, Харьков"),
                //    new AddressLocation("Енакиево")).Rows;

                var rows = Client.DistanceMatrix.GetDistanceMatrix(new AddressLocation(route.From),
                    new AddressLocation(route.To), language: "ru-RU").Rows;
                long distance = -1;
                string textDistance = string.Empty;
                foreach (var row in rows)
                {
                    foreach (var element in row.Elements)
                    {
                        if (element.Distance.Value <= 0) continue;
                        distance = element.Distance.Value;
                        textDistance = element.Distance.Text;
                        break;
                    }
                }
                var routeInfo = new RouteInfo();
                routeInfo.Route = $"{route.From} - {route.To}: {textDistance}";
                routeInfo.Distance = distance;
                routesWithDistance.Add(routeInfo);
            }
            return routesWithDistance;
        }
    }
}
