using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FluentJiraClient.Models;

namespace FluentJiraClient;

public class JiraClient : IResponseMappingStage {
    private readonly HttpClient _httpClient;
    private string _path;

    #region Constructors

    public JiraClient(string url, string authMethod, string username, string password) {
        _httpClient = new HttpClient() {
            BaseAddress = new Uri(Path.Combine(url, "rest/api/latest/")),
            DefaultRequestHeaders = {
                Authorization = new AuthenticationHeaderValue(authMethod, Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")))
            }
        };
    }

    public JiraClient(string url, string authMethod, string accessToken) {
        _httpClient = new HttpClient() {
            BaseAddress = new Uri(Path.Combine(url, "rest/api/latest/")),
            DefaultRequestHeaders = {
                Authorization = new AuthenticationHeaderValue(authMethod, accessToken)
            }
        };
    }

    #endregion
    
    #region Get

    public IResponseMappingStage Get(string path) {
        _path = path;
        return this;
    }

    #endregion
    
    #region Mapping

    public async Task<T> AsAsync<T>() {
        var response = await GetAndEnsureSuccessStatusCodeAsync();
        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync()) ?? throw new Exception("Failed to deserialize response");
    }

    public async Task<Issue> AsIssueAsync() => await AsAsync<Issue>();

    public async Task<string> AsRawAsync() {
        var response = await GetAndEnsureSuccessStatusCodeAsync();
        return await response.Content.ReadAsStringAsync();
    }
    
    private async Task<HttpResponseMessage> GetAndEnsureSuccessStatusCodeAsync() {
        var response = await _httpClient.GetAsync(_path);
        response.EnsureSuccessStatusCode();
        return response;
    }

    #endregion
}

public interface IResponseMappingStage {
    Task<T> AsAsync<T>();
    Task<string> AsRawAsync();
    Task<Issue> AsIssueAsync();
}