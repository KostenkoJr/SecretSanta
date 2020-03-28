using Autofac;
using Autofac.Integration.Mvc;
using SecretSanta.Data.EF.Repositories.RecipientRepository;
using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Data.EF.Repositories.WishRepository;
using SecretSanta.Services.AuthorizeService;
using SecretSanta.Services.UserServices;
using SecretSanta.Services.WishService;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using SecretSanta.Data.EF.Repositories.FeedbackRepository;
using SecretSanta.Services.FeedbackService;

namespace WishList.Utilities
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();
            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // регистрируем споставление типов
            #region User
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
            #endregion

            #region Recipient
            builder.RegisterType<RecipientRepository>().As<IRecipientRepository>();
            #endregion

            #region Authorization
            builder.RegisterType<AuthorizeService>().As<IAuthorizeService>();
            #endregion
            #region Wishes
            builder.RegisterType<WishRepository>().As<IWishRepository>();
            builder.RegisterType<WishService>().As<IWishService>();
            #endregion

            #region FeedbackForm
            builder.RegisterType<FeedbackRepository>().As<IFeedbackRepository>();
            builder.RegisterType<FeedbackService>().As<IFeedbackService>();
            #endregion

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}