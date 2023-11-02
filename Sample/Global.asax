using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WNDSS.Models.Common;
using WNDSS.Models.Domain;
using WNDSS.Models.Service;

namespace WNDSS
{
    public class MvcApplication : HttpApplication
    {
        AduitDataService _aduSrv = new AduitDataService();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();

            Utils.InitRemoteObject();
            Utils.ClearApplication(Consts.REMOTE_OBJ_CONN_STR);

            Dictionary<String, Hashtable> sessionList = new Dictionary<String, Hashtable>();
            Application[Consts.LIVE_SESSION_LIST] = sessionList;

            List<string> usedSessionList = new List<string>();
			Application[Consts.USED_SESSION_LIST] = usedSessionList;

			// 헤더정보 삭제.
			MvcHandler.DisableMvcResponseHeader = true;
        }
        protected void Application_End(Object sender, EventArgs e)
        {
            Utils.LogWrite($"Application_End", Utils.LogType.Info);

            Utils.ClearApplication(Consts.REMOTE_OBJ);

            Application.Clear();
        }
        

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            Utils.LogWrite(exception.ToString(), Utils.LogType.Info);
            
            Response.Clear();
            Server.ClearError();

            var httpContext = HttpContext.Current;
            httpContext.Response.Redirect("~/Errors", true);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            // 세션 유지시간 10분으로 설정.
            Session.Timeout = Consts.LOGIN_SESSION_TIME;
        }

        protected void Session_End(Object sender, EventArgs e)
        {
			var sessList = Application[Consts.LIVE_SESSION_LIST] as Dictionary<String, Hashtable>;

			//현재 로그인된 유저 정보
			if (Session[Consts.LOGIN_USER] is UserInfo loginInfo && sessList.ContainsKey(loginInfo?.userId))
            {
				_aduSrv.InsertAuditData("AUD701", loginInfo.userId, "세션종료", loginInfo.accessIP);
				sessList.Remove(loginInfo.userId);
            }
        }
    }
}
