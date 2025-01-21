using Application.Interface.Cdc;
using Asp.Versioning;
using Domain.Models.Cdc;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        {"cdcCvx",              "https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt" },
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
        await FetchCdcCvxAsync();
        await FetchCdcCvxCptAsync();
        await FetchCdcCvxManufacturerAsync();
        await FetchCdcCvxVaccineGroupAsync();
        await FetchCdcCvxVisAsync();
        await FetchCdcBarcodeAsync();
        await FetchCdcNdcAsync();
        await FetchCdcManufacturerAsync();
        return Ok();
    }

    private async Task FetchCdcManufacturerAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcManufacturer"]);
        IEnumerable<CdcManufacturer> _mfr = _data.Select(d => new CdcManufacturer()
        {
            MvxCode = d[0],
            ManufacturerName = d[1],
            ManufacturerNotes = d[2],
            ManufacturerStatus = d[3],
            LastUpdateDate = DateOnly.Parse(d[4])
        });
        _cdcManufacturer.SaveChanges(_mfr);
    }

    private async Task FetchCdcNdcAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcNdc"]);

        IEnumerable<CdcLookupNdc> _ndc = _data.Select(d => new CdcLookupNdc()
        {
            SaleNdc11 = d[0],
            SaleNdc10 = d[1],
            SaleProprietaryName = d[2],
            SaleLabeler = d[3],
            SalePackageForm = d[4],
            Route = d[5],
            SaleStatDate = DateOnly.Parse(d[6]),
            SaleEndDate = DateOnly.Parse(d[7]),
            SaleGtin = d[8],
            SaleLastUpdate = DateOnly.Parse(d[9]),
            VaccineSeason = d[10],
            UseNdc11 = d[11],
            UseNdc10 = d[12],
            UseUnitPackerForm = d[13],
            UseStartDate = DateOnly.Parse(d[14]),
            UseEndDate = DateOnly.Parse(d[15]),
            UseGtin = d[16],
            UserLastUpdate = DateOnly.Parse(d[17]),
            CdcCvxCode = d[18],
            CvxShortDescription = d[19],
            CvxLongDescription = d[20],
            CvxStatus = d[21],
            CvxEffectiveDate = DateOnly.Parse(d[22]),
            CvxRetiredDate = DateOnly.Parse(d[23]),
            MvxCode = d[24],
            Manufacturer = d[25],
            MvxStatus = d[26],
            CptCode = d[27],
            CptShortDescription = d[28],
            CptLongDescription = d[29],
            CptStatus = d[30],
        });

        _cdcLookupNdc.SaveChanges(_ndc);
    }

    private async Task FetchCdcBarcodeAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcBarcode"]);

        IEnumerable<CdcLookupBarcode> _barcode = _data.Select(d => new CdcLookupBarcode()
        {
            VisDocumentTypeDescription = d[0],
            EditionDate = DateOnly.FromDateTime(DateTime.Parse(d[1])),
            VisFullyEncodedString = d[2],
            VisGdtiCode = d[3],
            EditionStatus = d[4],
            LateUpdateDate = DateOnly.FromDateTime(DateTime.Parse(d[5])),
        });

        _cdcLookupBarcode.SaveChanges(_barcode);
    }

    private async Task FetchCdcCvxVisAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["CdcCvxVis"]);
        IEnumerable<CdcCvxVis> _vis = _data.Select(d => new CdcCvxVis()
        {
            CdcCvxCode = d[0],
            CvxVaccineDescription = d[1],
            VisFullyEncodedTextString = d[2],
            VisDocumentName = d[3],
            VisEditionDate = DateOnly.FromDateTime(DateTime.Parse(d[4])),
            VisEditionStatus = d[5]
        });
        _cdcCvxVis.SaveChanges(_vis);
    }

    private async Task FetchCdcCvxVaccineGroupAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvxVaccineGroup"]);
        IEnumerable<CdcCvxVaccineGroup> _vaccineGroup = _data.Select(d => new CdcCvxVaccineGroup()
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
        IEnumerable<CdcCvxManufacturer> _mfr = _data.Select(d => new CdcCvxManufacturer()
        {
            CdcProductName = d[0],
            ShortDescription = d[1],
            CdcCvxCode = d[2],
            Manufacturer = d[3],
            MvxCode = d[4],
            MvxStatus = d[5],
            ProductNameStatus = d[6],
            LastUpdatedDate = DateOnly.Parse(d[7]),
        });

        _cdcCvxManufacturer.SaveChanges(_mfr);
    }

    private async Task FetchCdcCvxCptAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvxCpt"]);

        IEnumerable<CdcCvxCpt> _cpts = _data.Select(d => new CdcCvxCpt()
        {
            CptCode = d[0],
            CptDescription = d[1],
            //d[2] always blank??
            CvxDescription = d[3],
            CdcCvxCode = d[4],
            Comments = d[5],
            LastUpdatedDate = DateOnly.Parse(d[6]),
            CptCodeId = string.IsNullOrWhiteSpace(d[7]) ? null : d[7]
        });
        _cdcCvxCpt.SaveChanges(_cpts);
    }

    private async Task FetchCdcCvxAsync()
    {
        var _data = await DownloadCdcDataAsync(_uri["cdcCvx"]);
        var _cvx = _data.Select(d => new CdcCvx()
        {
            CdcCvxCode = d[0],
            ShortDescription = d[1],
            FullVaccineName = d[2],
            Notes = d[3],
            VaccineStatus = d[4],
            NonVaccine = bool.Parse(d[5]),
            LastUpdatedDate = DateOnly.Parse(d[6])

        });
        _cdcCvx.SaveChanges(_cvx);
    }

    private async Task<List<string[]>> DownloadCdcDataAsync(string url)
    {
        var data = new List<string[]>();
        var client = _httpClientFactory.CreateClient();
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
