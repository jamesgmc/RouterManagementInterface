using System.Net.Http;
using HtmlAgilityPack;

namespace RouterManagement.Data;

public class RouterService
{

    public async Task MakeRequest()
    {
        var httpClient = new HttpClient();
        string RouterData;

        // Add the JSessionID cookie if your router requires it
        httpClient.DefaultRequestHeaders.Add("Cookie", "JSessionID=your-session-id");

        // Replace the URL with your router's management page
        var url = "http://your-router-ip/";

        try
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                var doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                // Extract data from the HTML using HtmlAgilityPack or your preferred library
                var dataNode = doc.DocumentNode.SelectSingleNode("//tag[@class='class-name']");

                if (dataNode != null)
                {
                    RouterData = dataNode.InnerText;
                }
                else
                {
                    RouterData = "Data not found in HTML.";
                }
            }
            else
            {
                RouterData = "Failed to retrieve data from the router.";
            }
        }
        catch (Exception ex)
        {
            RouterData = "An error occurred: " + ex.Message;
        }
    }
}
