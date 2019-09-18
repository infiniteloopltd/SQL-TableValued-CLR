using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using SQLAPI;

public partial class RegCheck
{
    [Microsoft.SqlServer.Server.SqlFunction(
        FillRowMethodName = "FillRow",
        TableDefinition = "Property nvarchar(500), TextValue nvarchar(500)")]
    public static IEnumerable Search(SqlString endpoint, SqlString registration, SqlString userame, SqlString password)
    {
        var client = new WebClient
        {
            Credentials = new NetworkCredential(userame.Value, password.Value)
        };
        var strUrl = "https://www.regcheck.org.uk/api/json.aspx/{0}/{1}";
        strUrl = string.Format(strUrl, endpoint.Value, registration.Value);
        var strJson = client.DownloadString(strUrl);
        var dict = Json.Deserialize(strJson) as Dictionary<string, object>;
        var lResult = new List<PropertyValue>();
        foreach (var key in dict.Keys)
        {
            if (dict[key] is Dictionary<string, object>)
            {
                // Handle 1 level of nesting.
                var dict2 = dict[key] as Dictionary<string, object>;
                foreach (var key2 in dict2.Keys)
                {
                    if (dict2[key2] is null) continue;
                    lResult.Add(new PropertyValue { Property = key, TextValue = dict2[key2].ToString() });
                }
            }
            else
            {
                if (dict[key] is null) continue;
                lResult.Add(new PropertyValue { Property = key, TextValue = dict[key].ToString() });
            }
        }
        return lResult;
    }

    public static void FillRow(object objProperties, out SqlString Property,
        out SqlString TextValue)
    {
        var property = (PropertyValue)objProperties;
        Property = property.Property;
        TextValue = property.TextValue;
    }

    public class PropertyValue
    {
        public string Property { get; set; }
        public string TextValue { get; set; }
    }


}
