using System.Security.Principal;

namespace DiplomaBack.DAL.Interfaces.Authorization
{
    public interface IPrincipal
    {
        IIdentity Identity { get; }
        bool IsInRole(string role);
    }
}
