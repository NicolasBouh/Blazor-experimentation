using Blazored.LocalStorage;
using BookStore.UI.Contracts;
using BookStore.UI.Models;
using BookStore.UI.Providers;
using BookStore.UI.Static;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UI.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationRepository(HttpClient client, 
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, EndPoints.LoginEndpoint);

            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            if(!response.IsSuccessStatusCode)
            {
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);

            // Store token
            await _localStorage.SetItemAsync("authToken", token.Token);

            // Change auth state
            await ((ApiAuthenticationStateProvider) _authenticationStateProvider)
                .LoggedIn();

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedOut();
        }

        public async Task<bool> Register(RegistrationModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, EndPoints.RegisterEndpoint);

            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
