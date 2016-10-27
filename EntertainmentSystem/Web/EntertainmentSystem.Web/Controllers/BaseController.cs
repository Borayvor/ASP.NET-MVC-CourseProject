namespace EntertainmentSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected ActionResult ConditionalActionResult<T>(Func<T> funcToPerform, Func<T, ActionResult> resultToReturn)
        {
            try
            {
                var result = funcToPerform();
                return resultToReturn(result);
            }
            catch (Exception ex)
            {
                return this.HttpNotFound(ex.Message);
            }
        }

        protected ActionResult ConditionalActionResult(Action actionToPerform, Func<ActionResult> resultToReturn)
        {
            try
            {
                actionToPerform();
                return resultToReturn();
            }
            catch (Exception ex)
            {
                return this.HttpNotFound(ex.Message);
            }
        }

        protected ActionResult IndependentActionResult(Action actionToPerform, ActionResult resultToReturn)
        {
            try
            {
                actionToPerform();
                return resultToReturn;
            }
            catch (Exception ex)
            {
                return this.HttpNotFound(ex.Message);
            }
        }
    }
}
