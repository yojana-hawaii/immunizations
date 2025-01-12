using Application.Interface.Cdc;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace api.Controllers;

[ApiVersion("1.0")]
[ApiController]
//[Route("api/v{version:apiVersion}/[Controller]")]
[Route("api/v1/[Controller]")]
public class CdcController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly ICdcCvx _cdcCvx;
    private readonly string _cdcCvxUri = "https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt";


    public CdcController(IHttpClientFactory httpClientFactory
        , ICdcCvx cdcCvx )
    {
        _httpClientFactory = httpClientFactory; 
        _cdcCvx = cdcCvx;
    }
    [HttpGet]
    public async Task<IActionResult> FetchAllAsync()
    {
        await FetchCdcCvxAsync();

        return Ok();
    }


    private async Task FetchCdcCvxAsync()
    {
        var _data = await DownloadCdcDataAsync(_cdcCvxUri);
        _cdcCvx.SaveChanges(_data);
    }

    private async Task<List<string[]>> DownloadCdcDataAsync(string url)
    {
        var data = new List<string[]>();
        var client  = _httpClientFactory.CreateClient();
        try
        {
            var content = await client.GetStringAsync(url);
            var lines = content.Split('\n');

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) 
                    continue;
                
                var delimited = line.Split('|').Select(d => d.Trim()).ToArray();
                
                data.Add(delimited);

            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

        return data;
    }


}
