using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Inventory.Website.Models
{

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IApplicationUser
    {
        private HttpContext context;

        public ApplicationUser(IHttpContextAccessor context)
        {
            this.context = context.HttpContext;
        }

        public bool IsSignedIn
        {
            get
            {
                //return context != null && !string.IsNullOrEmpty(this.context.User.Identity.Name);
                return context.User.Identities.Any(x => x.IsAuthenticated);
            }
        }

        public int Agency
        {
            get
            {
                return Convert.ToInt32(context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
        }

        public int UserID
        {
            get
            {
                return Convert.ToInt32(context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber).Value);
            }
        }

    }
}
