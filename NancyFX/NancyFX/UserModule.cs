using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using NancyFX.Boundary;
using NancyFX.BusinessLogic;
using NancyFX.Model;

namespace NancyFX
{
    public class UserModule : NancyModule
    {

        private readonly IUserService _userService;

        public UserModule()
        {
            this._userService=new UserService();
            RunRequest();
        }

        private void RunRequest()
        {
            Get["/users"] = parameters => Negotiate.WithStatusCode(HttpStatusCode.OK)
                .WithModel(_userService.GetAllUsers());

            Get["/users/{id}"] = parameters =>
            {
                int id = parameters.id;
                var user = _userService.GetUser(id);

                if (user == null)
                    return Negotiate
                        .WithStatusCode(HttpStatusCode.NotFound);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(user);
            };

            Post["/users"] = parameters =>
            {
                var user = this.Bind<User>();

                user.Id = _userService.AddUser(user.Name, user.Age);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(
                        new
                        {
                            user.Id
                        });
            };

            Delete["/users/{id}"] = parameters =>
            {
                int id = parameters.id;
                var user = _userService.GetUser(id);

                if (user == null)
                    return Negotiate
                        .WithStatusCode(HttpStatusCode.Gone);

                var newList = _userService.DeleteUser(id);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(newList);
            };
        }
    }
}
