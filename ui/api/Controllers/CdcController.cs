using Application.Interface.Cdc;
using Asp.Versioning;
using Domain.Models.Cdc;
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
    private readonly ICdcCvxCpt _cdcCvxCpt;
    private readonly ICdcCvxManufacturer _cdcCvxManufacturer;
    private readonly ICdcCvxVaccineGroup _cdcCvxVaccineGroup;
    private readonly ICdcCvxVis _cdcCvxVis;
    private readonly ICdcLookupBarcode _cdcLookupBarcode;
    private readonly ICdcLookupNdc _cdcLookupNdc;
    private readonly ICdcManufacturer _cdcManufacturer;

    private readonly Dictionary<string, string> _uri = new Dictionary<string, string>()
    {
        {"cdcCvx",           "https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt" },
        {"cdcCvxCpt",           "https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cpt.txt" },
        {"cdcCvxManufacturer",  "https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/TRADENAME.txt" },
        {"cdcCvxVaccineGroup",  "https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/VG.txt" },
        {"CdcCvxVis",           "https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cvx_vis.txt" },
        {"cdcBarcode",          "https://www.cdc.gov/iis/code-sets/downloads/vis-barcode-lookup-table" },
        {"cdcNdc",              "https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/NDC/get_all_ndc_display2.txt" },
        {"cdcManufacturer",     "https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/mvx.txt" },
    };


    public CdcController(IHttpClientFactory httpClientFactory, 
                ICdcCvx cdcCvx, ICdcCvxCpt cdcCvxCpt, ICdcCvxManufacturer cdcCvxManufacturer, 
                ICdcCvxVaccineGroup cdcCvxVaccineGroup, ICdcCvxVis cdcCvxVis, ICdcLookupBarcode cdcLookupBarcode,
                ICdcLookupNdc cdcLookupNdc, ICdcManufacturer cdcManufacturer)
    {
        _httpClientFactory = httpClientFactory; 
        _cdcCvx = cdcCvx;
        _cdcCvxCpt = cdcCvxCpt;
        _cdcCvxManufacturer = cdcCvxManufacturer;
        _cdcCvxVaccineGroup = cdcCvxVaccineGroup;
        _cdcCvxVis = cdcCvxVis;
        _cdcLookupBarcode = cdcLookupBarcode;
        _cdcLookupNdc = cdcLookupNdc;
        _cdcManufacturer = cdcManufacturer;
    }
    [HttpGet]
    public async Task<IActionResult> FetchAllAsync()
    {
        //await FetchCdcCvxAsync();
        //await FetchCdcCvxCptAsync();
        //await FetchCdcCvxManufacturerAsync();
        await FetchCdcCvxVaccineGroupAsync();
        //await FetchCdcCvxVisAsync();
        //await FetchCdcBarcodeAsync();
        //await FetchCdcNdcAsync();
        //await FetchCdcManufacturerAsync();
        return Ok();
    }

    private async Task FetchCdcManufacturerAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcManufacturer"]);
        _cdcManufacturer.SaveChanges(_data);
    }

    private async Task FetchCdcNdcAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcNdc"]);
        _cdcLookupNdc.SaveChanges(_data);
    }

    private async Task FetchCdcBarcodeAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcBarcode"]);
        _cdcLookupBarcode.SaveChanges(_data);
    }

    private async Task FetchCdcCvxVisAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["CdcCvxVis"]);
        _cdcCvxVis.SaveChanges(_data);
    }

    private async Task FetchCdcCvxVaccineGroupAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvxVaccineGroup"]);
        IEnumerable<CdcCvxVaccineGroup> _vaccineGroup = _data.Select( d => new CdcCvxVaccineGroup()
        {
            ShortDescription = d[0],
            CdcCvxCode = d[1],
            VaccineStatus = d[2],
            VaccineGroupName = d[3],
            VaccineGroupCvxCode = d[4],
        });

        _cdcCvxVaccineGroup.SaveChanges(_vaccineGroup);
    }

    private async Task FetchCdcCvxManufacturerAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvxManufacturer"]);
        _cdcCvxManufacturer.SaveChanges(_data);
    }

    private async Task FetchCdcCvxCptAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvxCpt"]);
        _cdcCvxCpt.SaveChanges(_data);
    }

    private async Task FetchCdcCvxAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvx"]);
        _cdcCvx.SaveChanges(_data);
    }

    private async Task<List<string[]>> DownloadCdcDataAsync(string url)
    {
        var data = new List<string[]>();
        var client  = _httpClientFactory.CreateClient();
        try
        {
            var content = await client.GetStringAsync(url);

            //

            var lines = content.Split('\n');
            lines = lines.Distinct().ToArray();

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
