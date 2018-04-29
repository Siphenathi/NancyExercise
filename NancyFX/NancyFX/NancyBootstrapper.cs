using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NancyFX
{
    public class NancyBootstrapper:DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //base.ApplicationStartup(container, pipelines);
            //pipelines.OnError+=(context)
        }
    }

    public class MyErrorConfiguration : Nancy.CustomErrors.CustomErrorsConfiguration
    {
        public MyErrorConfiguration():base()
        {
            // Map error status codes to custom view names
            ErrorViews[HttpStatusCode.NotFound] = "CustomNotFoundView";
            ErrorViews[HttpStatusCode.InternalServerError] = "CustomErrorView";
            ErrorViews[HttpStatusCode.Forbidden] = "Forbidden";
        }
    }

}
