#pragma checksum "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b8293fc5c0895afb5b830a30a293b55d0f257e6"
// <auto-generated/>
#pragma warning disable 1591
namespace TwitterStatsBlazorApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using TwitterStatsBlazorApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\_Imports.razor"
using TwitterStatsBlazorApp.Client.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/stats")]
    public partial class Stats : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Stats</h1>");
#nullable restore
#line 5 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
 if (counters == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p>Loading...</p>");
#nullable restore
#line 8 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "p");
            __builder.AddContent(3, "Elapsed Time: ");
            __builder.AddContent(4, 
#nullable restore
#line 11 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                  counters.ElapsedTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n");
            __builder.OpenElement(6, "p");
            __builder.AddContent(7, "Total Number of Tweets: ");
            __builder.AddContent(8, 
#nullable restore
#line 12 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                            counters.TotalNumberOfTweets

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
            __builder.OpenElement(10, "p");
            __builder.AddContent(11, "Average Tweets Per Hour: ");
            __builder.AddContent(12, 
#nullable restore
#line 13 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                             counters.AverageTweetsPerHour

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
            __builder.OpenElement(14, "p");
            __builder.AddContent(15, "Average Tweets Per Minute: ");
            __builder.AddContent(16, 
#nullable restore
#line 14 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                               counters.AverageTweetsPerMinute

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
            __builder.OpenElement(18, "p");
            __builder.AddContent(19, "Average Tweets Per Second: ");
            __builder.AddContent(20, 
#nullable restore
#line 15 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                               counters.AverageTweetsPerSecond

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n");
            __builder.OpenElement(22, "p");
            __builder.AddContent(23, "Percentage of Tweets with URL: ");
            __builder.AddContent(24, 
#nullable restore
#line 16 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                                   counters.PercentageOfTweetsWithUrl

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(25, "%");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n");
            __builder.OpenElement(27, "p");
            __builder.AddContent(28, "Percentage of Tweets with Pic: ");
            __builder.AddContent(29, 
#nullable restore
#line 17 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                                   counters.PercentageOfTweetsWithPic

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(30, "%");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n");
            __builder.OpenElement(32, "table");
            __builder.AddAttribute(33, "class", "table");
            __builder.AddMarkupContent(34, "<thead><tr><th>Top Hashtags</th>\r\n            <th>Total Tweets</th></tr></thead>\r\n    ");
            __builder.OpenElement(35, "tbody");
#nullable restore
#line 26 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
         foreach (var hashtag in @counters.TopHashtags)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(36, "tr");
            __builder.OpenElement(37, "td");
            __builder.AddContent(38, 
#nullable restore
#line 29 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                 hashtag.Key

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.OpenElement(40, "td");
            __builder.AddContent(41, 
#nullable restore
#line 30 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                 hashtag.Value

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 32 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n");
            __builder.OpenElement(43, "table");
            __builder.AddAttribute(44, "class", "table");
            __builder.AddMarkupContent(45, "<thead><tr><th>Top Domains</th>\r\n            <th>Total Tweets</th></tr></thead>\r\n    ");
            __builder.OpenElement(46, "tbody");
#nullable restore
#line 43 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
         foreach (var domain in @counters.TopDomains)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(47, "tr");
            __builder.OpenElement(48, "td");
            __builder.AddContent(49, 
#nullable restore
#line 46 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                 domain.Key

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n            ");
            __builder.OpenElement(51, "td");
            __builder.AddContent(52, 
#nullable restore
#line 47 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                 domain.Value

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 49 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n");
            __builder.OpenElement(54, "table");
            __builder.AddAttribute(55, "class", "table");
            __builder.AddMarkupContent(56, "<thead><tr><th>Top Emojis</th>\r\n            <th>Total Tweets</th></tr></thead>\r\n    ");
            __builder.OpenElement(57, "tbody");
#nullable restore
#line 60 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
         foreach (var emoji in @counters.TopEmojis)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(58, "tr");
            __builder.OpenElement(59, "td");
            __builder.AddContent(60, 
#nullable restore
#line 63 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                 emoji.Key

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n            ");
            __builder.OpenElement(62, "td");
            __builder.AddContent(63, 
#nullable restore
#line 64 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
                 emoji.Value

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 66 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 69 "C:\Users\mnguyen\source\repos\TwitterStatsBlazorApp\TwitterStatsBlazorApp\Client\Pages\Stats.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
