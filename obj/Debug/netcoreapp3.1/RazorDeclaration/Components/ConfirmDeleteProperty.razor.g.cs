#pragma checksum "C:\Projects\cps422-apartment-app\Components\ConfirmDeleteProperty.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d93d6626099b27aba2205f2e15ab9c3035da8516"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace apartment_app.Components
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
#line 1 "C:\Projects\cps422-apartment-app\Components\ConfirmDeleteProperty.razor"
using apartment_app.Data;

#line default
#line hidden
#nullable disable
    public partial class ConfirmDeleteProperty : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 15 "C:\Projects\cps422-apartment-app\Components\ConfirmDeleteProperty.razor"
       
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

    [Parameter] public Property Property { get; set; }

    public async Task Confirm()
    {
        if (Property != null)
        {
            PropertiesDB.Property.Remove(Property);
            await PropertiesDB.SaveChangesAsync();
        }

        await BlazoredModal.Close(ModalResult.Ok("Closing"));
        NavManager.NavigateTo("/");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PropertiesContext PropertiesDB { get; set; }
    }
}
#pragma warning restore 1591