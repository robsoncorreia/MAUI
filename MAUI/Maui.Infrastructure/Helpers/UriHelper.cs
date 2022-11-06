using System.Text.Json.Nodes;
using System.Text;

namespace Maui.Infrastructure.Helpers
{
    public class UriHelper
    {
        private static JsonNode jsonNode = JsonNode.Parse(Encoding.Default.GetString(Properties.Resources.Config));

        public static string CombineUri(params string[] uriParts)
        {
            string uri = string.Empty;
            if (uriParts != null && uriParts.Length > 0)
            {
                char[] trims = new char[] { '\\', '/' };
                uri = (uriParts[0] ?? string.Empty).TrimEnd(trims);
                for (int i = 1; i < uriParts.Length; i++)
                {
                    uri = string.Format("{0}/{1}", uri.TrimEnd(trims), (uriParts[i] ?? string.Empty).TrimStart(trims));
                }
            }
            return uri;
        }
        public static string GetConfig(string key = "connectionString") => (string)jsonNode!["Data"]![key];
    }
}