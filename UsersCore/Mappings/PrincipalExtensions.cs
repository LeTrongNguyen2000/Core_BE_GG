using IdentityModel;
using System.Security.Claims;
using System.Security.Principal;

namespace UserCore.Mappings
{
    /// <summary>
    /// Princial extension
    /// </summary>
    public static class PrincipalExtensions
    {
        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="principal">Principal object</param>
        /// <returns>User Id</returns>
        public static string GetUserId(this IPrincipal principal)
        {
            if (principal == null)
            {
                return null;
            }

            var claimsPrincipal = principal as ClaimsPrincipal;

            if (claimsPrincipal != null)
            {
                foreach (var identity in claimsPrincipal.Identities)
                {
                    Claim idClaim = identity.FindFirst(JwtClaimTypes.Id);

                    if (idClaim != null)
                    {
                        return idClaim.Value;
                    }
                }
            }

            return null;
        }

        public static string GetUserName(this IPrincipal principal)
        {
            if (principal == null)
            {
                return null;
            }

            var claimsPrincipal = principal as ClaimsPrincipal;

            if (claimsPrincipal != null)
            {
                foreach (var identity in claimsPrincipal.Identities)
                {
                    Claim idClaim = identity.FindFirst(JwtClaimTypes.Name);

                    if (idClaim != null)
                    {
                        return idClaim.Value;
                    }
                }
            }

            return null;
        }
    }
}
