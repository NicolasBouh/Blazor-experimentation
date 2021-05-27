using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UI.Static
{
    public static class EndPoints
    {
        public static string BaseUrl = "https://localhost:44370/";

        public static string AuthorsEndpoint = $"{BaseUrl}api/authors/";

        public static string BooksEndpoint = $"{BaseUrl}api/books/";

        public static string RegisterEndpoint = $"{BaseUrl}api/Users/register";

        public static string LoginEndpoint = $"{BaseUrl}api/Users/login";

    }
}
