using System;
using System.Web; // Added for Server and Session

namespace LMSProject
{
    public partial class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Application has started at " + DateTime.Now);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Application has shut down at " + DateTime.Now);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                System.Diagnostics.Debug.WriteLine("Error occurred: " + ex.Message + " at " + DateTime.Now);
                Server.ClearError(); // Clears the error from the server context
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["UserStartTime"] = DateTime.Now;
            System.Diagnostics.Debug.WriteLine("New session started at " + DateTime.Now);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session has ended at " + DateTime.Now);
        }
    }
}