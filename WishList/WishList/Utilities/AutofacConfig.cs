using Autofac;
using Autofac.Integration.Mvc;
using SecretSanta.Data.EF.Repositories.GroupRepository;
using SecretSanta.Data.EF.Repositories.RecipientRepository;
using SecretSanta.Data.EF.Repositories.UserRepository;
using SecretSanta.Services.AuthorizeService;
using SecretSanta.Services.GroupService;
using SecretSanta.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            #region Group
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<GroupService>().As<IGroupService>();
            #endregion

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}