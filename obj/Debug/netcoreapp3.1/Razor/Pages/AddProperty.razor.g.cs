#pragma checksum "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24aeabf64f7a40cafa1214d5de2fee1614f31f73"
// <auto-generated/>
#pragma warning disable 1591
namespace apartment_app.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\cps422-apartment-app\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\cps422-apartment-app\_Imports.razor"
using apartment_app;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\cps422-apartment-app\_Imports.razor"
using apartment_app.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\cps422-apartment-app\_Imports.razor"
using apartment_app.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\cps422-apartment-app\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\cps422-apartment-app\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
using apartment_app.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/addproperty")]
    public partial class AddProperty : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<link href=\"css/AddProperty.css\" rel=\"stylesheet\">\r\n\r\n");
            __builder.AddMarkupContent(1, "<h1>Add Property</h1>\r\n\r\n(all submissions are subject to approval)\r\n<br>\r\n<br>\r\n\r\n");
            __builder.OpenComponent<apartment_app.Components.PropertyComponent>(2);
            __builder.AddAttribute(3, "Property", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<apartment_app.Data.Property>(
#nullable restore
#line 17 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
                              Property

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "PropertyChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<apartment_app.Data.Property>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<apartment_app.Data.Property>(this, 
#nullable restore
#line 17 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
                                                          CreateProperty

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "h3");
            __builder.AddAttribute(7, "style", "color:red");
            __builder.AddContent(8, " ");
            __builder.AddContent(9, 
#nullable restore
#line 19 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
                        message

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(10, " ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "C:\Projects\cps422-apartment-app\Pages\AddProperty.razor"
       

    [Parameter]
    public int? Id { get; set; }

    public Property Property { get; set; } = new Property();

    private string message = "";

    private async Task CreateProperty(Property newProperty)
    {
        this.Property = newProperty;
        if (PropertiesDB.Property.Any(e => ((e.Name == Property.Name) || (e.AddressLine1 == Property.AddressLine1))))
        {
            message = "Property with given Name or address already exists!";
        }
        else
        {
            PropertiesDB.Property.Add(this.Property);
            await PropertiesDB.SaveChangesAsync();
            message = "";
            NavManager.NavigateTo("/viewproperty/" + this.Property.ID);
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PropertiesContext PropertiesDB { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
