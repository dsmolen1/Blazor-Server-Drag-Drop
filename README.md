<p>
    This app demonstrates a technique for handling drag/drop in Blazor Server apps. All of the bookkeeping is handled
    by the browser, but the DOM is not updated in Javascript. Only when a card is dropped do we pass that on to
    the C# code to update the app state and re-render the UI.
</p>
<p>
    This app requires the Microsoft.AspNetCore.SignalR.Client NuGet package.
</p>
<p>
    Modified files:
    <ul>
        <li><b>_Host.cshtml</b>: add script tag</li>
        <li><b>Startup.cs</b>: add <code>endpoints.MapHub&lt;MyHub&gt;("MyHub");</code></li>
        <li><b>site.js</b>: event handlers for the drag/drop operation</li>
        <li><b>MyHub.cs</b>: maintains the state of the app</li>
        <li><b>Index.razor</b>: the UI</li>
    </ul>
</p>
