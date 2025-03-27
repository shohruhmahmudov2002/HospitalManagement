using HospitalManagement.Settings;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Service;

public class PdpService
{
    private readonly HttpClient _httpClient;
    private readonly PdpSetting _pdpSetting;
    public PdpService(HttpClient httpClient, IOptions<PdpSetting> pdpSetting)
    {
        _httpClient = httpClient;
        _pdpSetting = pdpSetting.Value;
    }

    public async Task<string> GetPdpData()
    {
        _httpClient.BaseAddress = new Uri(_pdpSetting.Endpoint);

        var response = await _httpClient
            .GetAsync($"?database_id={_pdpSetting.DatabaseId}&page_count={_pdpSetting.BatchCount}&all=true");

        return await response.Content.ReadAsStringAsync();
    }
}
