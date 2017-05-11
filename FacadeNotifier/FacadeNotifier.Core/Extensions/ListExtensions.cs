namespace FacadeNotifier.Core.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ListExtensions
    {
        public static bool AnyOrNotNull<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }
    }
}