using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BillDesk
{
    public class Integration :Iintegration
    {
        public async Task<string> CreateHMAC()
        {
            string result="Empty";
            using (HttpClient client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes("client1:3FF9CBF87A66A452");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.BaseAddress = new Uri("https://uat.billdesk.com/hgpay/v2_1/abcd/customers/12345/billpay/billers");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("BD-Traceid", "a453c1353");
                client.DefaultRequestHeaders.Add("BD-Timestamp", "20160528121320");
               var inputBody= "SHA256 : 170AE002EFA016D1AB3CC2CF82B4E2B57BE2E7FCE92D4DB1355D25718A039EBC";
                var json = JsonConvert.SerializeObject(inputBody);
                var data = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");

                try
                {
                    var response = await client.PostAsync(client.BaseAddress, data);
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured at the time of Creating data sting ", ex);
                }
            }
            return result;
        }

        public async Task<string> CreateHMAC(DataEntryModel dataEntry)
        {
            string result = "Empty";
            using (HttpClient client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes(dataEntry.Client+ ":"+dataEntry.ClientSercet);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                try
                {
                    client.BaseAddress = new Uri(dataEntry.BaseUrl + "/hgpay/v2_1/" + dataEntry.SourceId + "/customers/" + dataEntry.CustomerId + "/billpay/billers");
                }
                catch
                {
                    return("Invalid URI: The format of the URI is incorrect.");
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("BD-Traceid", dataEntry.BDTraceid);
                client.DefaultRequestHeaders.Add("BD-Timestamp", dataEntry.BDTimestamp);
                var inputBody = "SHA256 :"+ dataEntry.SHA256Id;
                var json = JsonConvert.SerializeObject(inputBody);
                var data = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");
                try
                {
                    var response = await client.PostAsync(client.BaseAddress, data);
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured at the time of Creating data sting ", ex);
                }
            }
            return result;
        }
    }
}
