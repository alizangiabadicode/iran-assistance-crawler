using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace web_crawler_using_cSharp
{
    static class LoadNextPage
    {
        public static string Next(int pageNum)
        {
            var client = new RestClient("https://www.iranassistance.com/CareCenter/Search");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authority", "www.iranassistance.com");
            request.AddHeader("pragma", "no-cache");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept", "*/*");
            request.AddHeader("x-requested-with", "XMLHttpRequest");
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
            request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("origin", "https://www.iranassistance.com");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("referer", "https://www.iranassistance.com/CareCenter/Index");
            request.AddHeader("accept-encoding", "gzip, deflate, br");
            request.AddHeader("accept-language", "en-US,en;q=0.9,nl;q=0.8,fa;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.2.1679033063.1572172240; BasePage=/Home/Index; Tips=true; _gid=GA1.2.1284751086.1581073569; ASP.NET_SessionId=1fs0yvb2ygrnzb2gt2tdvor3; _gat=1; __RequestVerificationToken=HHwEU-MUUWXLgM8DDRNmBkE_cJ_1EPAwhWBhzz4Nf1CYafA9sLjGxYHfkYJqODwTAMd4GOndVigfHZ3dhtCxbbhNmBvuAweQ_KWvESYmV0Y1");
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", $"__RequestVerificationToken=bXrTZPmZtGGhirvTbb-BlksPlkrxijlj6HaZWwi0UqUhZJk4kWWvnVYnqOUMGiylHwS38V5SFfQqStf-AoZ8AlOWDt_R4GizzAdoU4Nxitc1&SearchString=&ProvinceId=&KindService=&Status=true&page={pageNum}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string Detail(string id)
        {
            var client = new RestClient($"https://www.iranassistance.com/CareCenter/Popup/{id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("authority", "www.iranassistance.com");
            request.AddHeader("pragma", "no-cache");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-fancybox", "true");
            request.AddHeader("accept", "text/html, */*; q=0.01");
            request.AddHeader("x-requested-with", "XMLHttpRequest");
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("referer", "https://www.iranassistance.com/CareCenter/Index");
            request.AddHeader("accept-encoding", "gzip, deflate, br");
            request.AddHeader("accept-language", "en-US,en;q=0.9,nl;q=0.8,fa;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.2.1679033063.1572172240; BasePage=/Home/Index; Tips=true; _gid=GA1.2.1284751086.1581073569; ASP.NET_SessionId=1fs0yvb2ygrnzb2gt2tdvor3; __RequestVerificationToken=HHwEU-MUUWXLgM8DDRNmBkE_cJ_1EPAwhWBhzz4Nf1CYafA9sLjGxYHfkYJqODwTAMd4GOndVigfHZ3dhtCxbbhNmBvuAweQ_KWvESYmV0Y1");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
