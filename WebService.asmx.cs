using Newtonsoft.Json;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebserviceDemo
{
    // Use "Namespace" attribute with an unique name,to make service uniquely discoverable
    [WebService(Namespace = "http://tempuri.org/")]

    // To indicate service confirms to "WsiProfiles.BasicProfile1_1" standard,   
    // if not, it will throw compile time error.  
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    // To restrict this service from getting added as a custom tool to toolbox  
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX 
    [ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false, XmlSerializeString = false)]
        public string GetOrderDetails()
        {
            string Data = "";

            DataTable dt = GetDataFromDB.GetOrderDetails();
            if (dt.Rows.Count > 0)
                Data = JsonConvert.SerializeObject(new jResponse(false, "Success", dt));
            else
                Data = JsonConvert.SerializeObject(new jResponse(true, "", null));

            return Data;
        }

        //Creating Method with Parameters

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false, XmlSerializeString = false)]
        public string GetOrderDetailsByDate(string FromDate, string ToDate)
        {
            string Data = "";
            DataTable dt = GetDataFromDB.GetOrderDetailsByDate(FromDate, ToDate);
            if (dt.Rows.Count > 0)
                Data = JsonConvert.SerializeObject(new jResponse(false, "Success", dt));
            else
                Data = JsonConvert.SerializeObject(new jResponse(true, "", null));
            return Data;
        }

        //Creating Method with Security 

        //Token for Security
        string SecurityToken = HttpContext.Current.Request.Headers["Token"];

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false, XmlSerializeString = false)]
        public string GetOrderDetailsByDateWithSecurity(string FromDate, string ToDate)
        {
            string Data = "";
            if (SecurityToken == "WsDMVKMsrtkuVURZxd")
            {
                DataTable dt = GetDataFromDB.GetOrderDetailsByDate(FromDate, ToDate);
                if (dt.Rows.Count > 0)
                    Data = JsonConvert.SerializeObject(new jResponse(false, "Success", dt));
                else
                    Data = JsonConvert.SerializeObject(new jResponse(true, "", null));
                return Data;
            }
            else
            {
                Data = JsonConvert.SerializeObject(new jResponse(true, "Invalid Security Token.", null));
                return Data;
            }
        }       
    }
}
