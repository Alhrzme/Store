using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Store.Pages.Helpers
{
    public class GetImageHandler : UrlRoutingHandler
    {
        protected override void VerifyAndProcessRequest(IHttpHandler httpHandler, HttpContextBase httpContext)
        {
            RouteData routeData = httpContext.Request.RequestContext.RouteData;

            httpContext.Response.ContentType = "image/jpeg";

            string connectionString =
              WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            string id = (string)routeData.Values["id"];
            if (id == null)
            {
                throw new ApplicationException("Должен быть указан идентификатор");
            }

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetImages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader r =
                  cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                if (r.Read())
                {
                    int bufferSize = 100;                   
                    byte[] bytes = new byte[bufferSize];    
                    long bytesRead;                         
                    long readFrom = 0;                      

                    do
                    {
                        bytesRead = r.GetBytes(0, readFrom, bytes, 0, bufferSize);
                        httpContext.Response.BinaryWrite(bytes);
                        readFrom += bufferSize;
                    } while (bytesRead == bufferSize);
                }
                r.Close();
            }
            finally
            {
                con.Close();
            }
        }
    }
}