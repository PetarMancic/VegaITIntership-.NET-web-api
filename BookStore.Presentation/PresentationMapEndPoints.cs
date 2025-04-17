using Bookstore.Presentation.EndPoints;
using BookStore.Presentation.EndPoints;

namespace BookStore.Presentation;
public static class PresentationMapEndPoints
{
    public static void MapEndPointsPresentation(this WebApplication app)
    {
        app.MapAuthorEndpoints();
        app.MapBookEndpoints();
        app.MapPurchaseItemEndPoints();
    }
}
