﻿using static System.Console;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;
using CryptographyLib;

namespace SecureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // dummy usernames, passwords, and roles
            Protector.Register("Alice", "Pa$$w0rd", new[] { "Admins" });
            Protector.Register("Bob", "Pa$$w0rd", new[] { "Sales", "TeamLeads" });
            Protector.Register("Eve", "Pa$$w0rd");

            Write($"Enter your user name: ");
            string username = ReadLine();
            Write($"Enter your password: ");
            string password = ReadLine();
            Protector.LogIn(username, password);
            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("Log in failed.");
                return;
            }
            var p = Thread.CurrentPrincipal;
            WriteLine($"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine($"AuthenticationType: {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");
            if (p is ClaimsPrincipal)
            {
                WriteLine($"{p.Identity.Name} has the following claims:");
                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"{claim.Type}: {claim.Value}");
                }
            }

            try
            {
                SecureFeature();
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }

        }

        static void SecureFeature()
        {
            _ = Thread.CurrentPrincipal ??
                throw new SecurityException("A user must be logged in to access this feature.");

            _ = Thread.CurrentPrincipal.IsInRole("Admins") ? 0 : throw new SecurityException("User must be a member of Admins to access this feature.");

            WriteLine("You have access to this secure feature (admins only).");
        }
    }
}
