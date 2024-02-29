namespace Application.Extensions;

public static class ListHelper
{
    public static IList<T> GetPage<T>(this IList<T> list, int page, int pageSize) {
        return list.Skip(page*pageSize).Take(pageSize).ToList();
    }
}