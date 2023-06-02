using AdminSiteAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;



namespace adminSiteAPI.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("api/Login/authenticateUser/{username}/{passcode}")]
        public Boolean authenticateUser(string username, string passcode)
        {
            SqlConnection con = new SqlConnection(@"Data Source=BHAVANACV-LT;Initial Catalog=admin_site;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Login where username=@username and passcode=@passcode", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@passcode", passcode);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                return true;
            else
                return false;
        }
    }
}