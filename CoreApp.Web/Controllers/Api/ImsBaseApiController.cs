using CoreApp.Web.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CoreApp.Web.Controllers.Api
{
    public class ImsBaseApiController : Controller
    {
        private int? _currentUserId;
        private int? _currentEmployeeId;

        public int? CurrentUserId
        {
            get
            {
                if (_currentUserId == null)
                {
                    if (User != null && User.Identity.IsAuthenticated)
                    {
                        var identity = User.Identity as ClaimsIdentity;
                        _currentUserId = int.Parse(identity.Claims.Where(c => c.Type == ClaimType.UserId).Select(c => c.Value).FirstOrDefault());
                    }
                }
                return _currentUserId;
            }
        }

        public int? CurrentEmployeeId
        {
            get
            {
                if (_currentEmployeeId == null)
                {
                    if (User != null && User.Identity.IsAuthenticated)
                    {
                        var identity = User.Identity as ClaimsIdentity;
                        _currentEmployeeId = int.Parse(identity.Claims.Where(c => c.Type == ClaimType.EmployeeId).Select(c => c.Value).FirstOrDefault());
                    }
                }
                return _currentEmployeeId;
            }
        }
    }
}