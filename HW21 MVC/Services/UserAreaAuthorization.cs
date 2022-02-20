using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace HW21_MVC.Services
{
    public class UserAreaAuthorization : IControllerModelConvention
    {
        private readonly string m_area;

        private readonly string m_policy;

        public UserAreaAuthorization(string area, string policy)
        {
            m_area = area;

            m_policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(
                x => x is AreaAttribute && (x as AreaAttribute).
                RouteValue.Equals(m_area, StringComparison.OrdinalIgnoreCase)
                || controller.RouteValues.Any(r=> r.Key.Equals("area"
                ,StringComparison.OrdinalIgnoreCase) && r.Value.Equals(m_area,
                StringComparison.OrdinalIgnoreCase))
                ))
            {
                controller.Filters.Add(new AuthorizeFilter(m_policy));
            }
        }
    }
}
