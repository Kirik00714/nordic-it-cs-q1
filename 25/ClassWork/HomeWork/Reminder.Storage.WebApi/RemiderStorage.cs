using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Reminder.Storage.WebApi
{
    class RemiderStorage : IReminderStorage
    {
        private readonly HttpClient _client;
        public RemiderStorage(HttpClient client)
        {
            _client = client;
        }

        public void Add(ReminderItem item)
        {
            var response = Execute($"api/reminders/{item.Id}", HttpMethod.Post, item.ToContent());
            response.EnsureSuccessStatusCode();
        }

        public List<ReminderItem> FindBy(ReminderItemFilter filter)
        {
            var response = Execute($"api/reminders/{filter.}", HttpMethod.Get);
            response.EnsureSuccessStatusCode();
            return response.Content.ToObject<ReminderItem>();
        }

        public ReminderItem FindById(Guid id)
        {
            var response = Execute($"api/reminders/{id}", HttpMethod.Get);
            response.EnsureSuccessStatusCode();
            return response.Content.ToObject<ReminderItem>();
        }

        public void Update(ReminderItem item)
        {
            var response = Execute($"api/reminders/{item.Id}", HttpMethod.Put, item.ToContent());
            response.EnsureSuccessStatusCode();
        }
        private HttpResponseMessage Execute(
            string url,
            HttpMethod method,
            StringContent content = default)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };
            var response = _client.SendAsync(request)
                .GetAwaiter()
                .GetResult();
            return response;
        }
        
        
    }
    public static class Converter
    {
        public static StringContent ToContent<T>(this T item)
        {
            var json = JsonSerializer.Serialize(item);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        public static T ToObject<T>(this HttpContent content)
        {
            var json = content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonSerializer.Deserialize<T>(json);
            return result;

        }
    }
}
