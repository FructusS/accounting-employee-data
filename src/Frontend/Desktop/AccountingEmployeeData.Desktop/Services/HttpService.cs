using System;
using System.Net.Http;

namespace AccountingEmployeeData.Desktop.Services;

public static class HttpService
{
    /// <summary>
    /// Создание экземпляра http client`a c обеспечением потокобезопасности
    /// </summary>
    private static HttpClient? _httpClient;
    private const string BaseUrl = "http://localhost:5271/api/";
    public static HttpClient GetHttpClient()
    {
        var locker = new object();
        if (_httpClient == null)
        {
            lock (locker)
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient()  {
                        BaseAddress = new Uri(BaseUrl),
                    };

                    return _httpClient;
                }
                return _httpClient;
            }
        }
        return _httpClient;
    }
}