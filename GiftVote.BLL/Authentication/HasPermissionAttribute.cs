using Microsoft.AspNetCore.Authorization;

namespace GiftVote.BLL.Authentication
{
    public sealed class HasPermissionAttribute(Permission permission) : AuthorizeAttribute(permission.ToString())
    {
    }
}
