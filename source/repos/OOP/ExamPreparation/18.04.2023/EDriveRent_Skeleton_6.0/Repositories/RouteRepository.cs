using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            IRoute route = routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier));
            if (route == null) { return  null; }
            else return route;
        }

        public IReadOnlyCollection<IRoute> GetAll() => routes.AsReadOnly();

        public bool RemoveById(string identifier)
        {
            IRoute route = FindById(identifier);
            if (route == null) 
            { return false;}
            else
            {
                routes.Remove(route);
                return true;
            }
        }
    }
}
