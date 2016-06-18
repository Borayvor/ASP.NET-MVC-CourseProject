namespace EntertainmentSystem.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {
        public static GridBuilder<T> FullFeaturedGrid<T>(
            this HtmlHelper helper,
            string controllerName,
            Expression<Func<T, object>> modelIdExpression,
            Action<GridColumnFactory<T>> columns = null)
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
                .ToolBar(toolbar => toolbar.Create())
                .Editable(edit => edit.Mode(GridEditMode.PopUp))
                .DataSource(data =>
                    data
                        .Ajax()
                        .PageSize(10)
                        .Model(m => m.Id(modelIdExpression))
                        .Read(read => read.Action("EditingPopupRead", controllerName))
                        .Create(create => create.Action("EditingPopupCreate", controllerName))
                        .Update(update => update.Action("EditingPopupUpdate", controllerName))
                        .Destroy(destroy => destroy.Action("EditingPopupDestroy", controllerName)));
        }
    }
}
