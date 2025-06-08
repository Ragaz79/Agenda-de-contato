using X.PagedList.Mvc.Core;

namespace AgendaContato.Helpers
{
    public static class PaginationHelper
    {
        public static PagedListRenderOptions Bootstrap5()
        {
            return new PagedListRenderOptions
            {
                DisplayLinkToFirstPage = PagedListDisplayMode.Always,
                DisplayLinkToLastPage = PagedListDisplayMode.Always,
                DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                DisplayLinkToNextPage = PagedListDisplayMode.Always,
                DisplayLinkToIndividualPages = true,
                MaximumPageNumbersToDisplay = 5,
                ContainerDivClasses = new[] { "d-flex", "justify-content-center" },
                UlElementClasses = new[] { "pagination" },
                LiElementClasses = new[] { "page-item" },
                PageClasses = new[] { "page-link" },
                
            };
        }
    }
}