using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OnlineShop.ApplicationServices")]
[assembly: InternalsVisibleTo("OnlineShop.Infrastructure")]
[assembly: InternalsVisibleTo("OnlineShop.Configuration")]
[assembly: InternalsVisibleTo("OnlineShop.UnitTest")]
[assembly: InternalsVisibleTo("OnlineShop.BDD")]

namespace OnlineShop.Domain
{
    internal class ExposeInternalTypes
    {
    }
}
