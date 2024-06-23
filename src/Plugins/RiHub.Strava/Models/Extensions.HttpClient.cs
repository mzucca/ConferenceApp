﻿using Newtonsoft.Json;

namespace RiHub.Strava.Models;

static class HttpClientExtensions
{
    public static async Task<T> SendAsync<T>(this HttpClient client, HttpRequestMessage request)
    {
        var response = await client.SendAsync(request);
        // TODO: error handling
        var responseAsString = await response.Content.ReadAsStringAsync();
        try
        {
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(responseAsString);
        }
        catch (HttpRequestException httpRequestEx)
        {
            throw new System.Exception(responseAsString, httpRequestEx);
        }
    }
}
