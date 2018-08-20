﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MatrixMax.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool login = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Login";
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario == null && !login) filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "Login", action = "Index"}
                )
            );

        }
    }
}