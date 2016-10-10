namespace EntertainmentSystem.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoAdminHelpers
    {
        public static GridBuilder<T> FullFeaturedAdminGrid<T>(
            this HtmlHelper helper,
            string controllerName,
            Expression<Func<T, object>> modelIdExpression,
            Action<GridColumnFactory<T>> columns = null,
            object readRouteValues = null)
            where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c => c.Edit());
                    cols.Command(c => c.Destroy());
                };
            }

            return helper.Kendo()
                .Grid<T>()
                .Name("grid")
                .Columns(columns)
                .ColumnMenu()
                .Pageable(pageable => pageable
                .Refresh(true)
                .PageSizes(true)
                .ButtonCount(5))
                .Scrollable()
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp))
                .HtmlAttributes(new { style = "height: 500px;" })
                .DataSource(data =>
                    data
                        .Ajax()
                        .PageSize(10)
                        .Model(m => m.Id(modelIdExpression))
                        .Read(read => read.Action("Read", controllerName, readRouteValues).Data("sendAntiForgery"))
                        .Update(update => update.Action("Update", controllerName).Data("sendAntiForgery"))
                        .Destroy(destroy => destroy.Action("DestroyPermanent", controllerName).Data("sendAntiForgery")));
        }
    }
}
