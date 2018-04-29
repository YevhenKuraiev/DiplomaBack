using System;
using System.Collections.Generic;
using System.Linq;
using DiplomaBack.BLL.BusinessModels;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using HamiltonianGraph;

namespace DiplomaBack.BLL
{
    public class DistanceBuilder
    {
        private static readonly MapsAPIClient Client = new MapsAPIClient("AIzaSyBP1XG4Z5nph35aVskXQuhBmESwZc3_JXU");

        public List<RouteInfo> GetCourierRoute(List<Route> routes, int countOrders)
        {
            var routesWithDistance = GetRoutesWithDistance(routes);
            return GetShortRoute(routesWithDistance, countOrders);
        }

        private List<RouteInfo> GetRoutesWithDistance(List<Route> routes)
        {
            var routesWithDistance = new List<RouteInfo>();
            foreach (var route in routes)
            {
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
                //routeInfo.From = route.From;
                //routeInfo.To = route.To;
                routeInfo.FullRoute = $"{GetShortAddress(route.From)} - {GetShortAddress(route.To)}: {textDistance}";
                routeInfo.Distance = distance;
                routesWithDistance.Add(routeInfo);

            }
            return routesWithDistance;
        }

        private List<RouteInfo> GetShortRoute(List<RouteInfo> routesInfo, int countRoutes)
        {
            routesInfo.OrderBy(x => x.Distance);
            var weights = GetHamiltonianGraph(routesInfo, countRoutes);
            var shorterRoutes = new BranchAndBound(weights).GetShortestHamiltonianCycle().ToList();
            shorterRoutes.RemoveAt(0);
            var shortRoute = new List<RouteInfo>();
            var counter = 0;
            for (int i = 0; i < shorterRoutes.Count; i++)
            {
                foreach (var routeInfo in routesInfo)
                {
                    if (weights[counter, shorterRoutes[i]] == routeInfo.Distance)
                    {
                        shortRoute.Add(routeInfo);
                        counter = shorterRoutes[i];
                        break;
                    }
                }
            }
            return shortRoute;
        }

        private int?[,] GetHamiltonianGraph(List<RouteInfo> routesInfo, int countRoutes)
        {
            var weights = new int?[countRoutes, countRoutes];
            var counter = 0;
            for (int i = 0; i < countRoutes; i++)
            {
                for (int j = 0; j < countRoutes; j++)
                {
                    if (i == j) continue;
                    weights[i, j] = (int)routesInfo[counter++].Distance;
                }
            }
            return weights;
        }


        private string GetShortAddress(string address)
        {
            var counter = 0;
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == ',')
                {
                    counter++;
                }
                if (counter == 2)
                {
                    return address.Substring(0, i);
                }
            }
            return address;
        }

    }
}
