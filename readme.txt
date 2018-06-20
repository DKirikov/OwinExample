Requirements: VS 2013, .NET Framework 4.5.1

Description:
This example shows how to work with Microsoft.Owin (Open Web Interface for .NET with ASP.NET Core).
The example has an authorization system. It works by using cookies.
It contains APIs for login & logout:
http://127.0.0.1:9994/api/account/login?email=test0@gmail.com&password=somePassword0
http://127.0.0.1:9994/api/account/logout
There are 2 valid accounts: (email = "test0@gmail.com", password = "somePassword0") & ("test1@gmail.com", password = "somePassword1")

You must login before you call basic APIs, for example
http://127.0.0.1:9994/api/test/generatestring

Also, this example shows how to work with IoC (Microsoft.Practices.Unity).

WebApiHelpPageSelfHost Project can be added to the solution if you need project documentation.
https://code.msdn.microsoft.com/ASPNET-Web-API-Help-Page-40e1a68e
It's based on Microsoft.AspNet.WebApi.HelpPage.