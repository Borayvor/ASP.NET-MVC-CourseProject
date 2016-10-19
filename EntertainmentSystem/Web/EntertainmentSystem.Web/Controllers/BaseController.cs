namespace EntertainmentSystem.Web.Controllers
{
    using System;
    using System.Linq;
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
            if (this.ModelState.IsValid)
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
            else
            {
                return this.HttpNotFound(this.ModelState.Values.FirstOrDefault().ToString());
            }
        }

        protected ActionResult ConditionalActionResult(Action actionToPerform, Func<ActionResult> resultToReturn)
        {
            if (this.ModelState.IsValid)
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
            else
            {
                return this.HttpNotFound(this.ModelState.Values.FirstOrDefault().ToString());
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
