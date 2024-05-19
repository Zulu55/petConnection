﻿using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace petConnection.FrontEnd.AuthenticationProviderTest
{
	public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Javier"),
                new Claim("LastName", "Pedroza"),
                new Claim(ClaimTypes.Name, "javier@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        }
    }
}

