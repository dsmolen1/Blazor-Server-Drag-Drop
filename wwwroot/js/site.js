/* drag drop support
 The idea is to let all the drag-drop operations take place in the browser, but not modify the DOM.
 Then call a C# method which handles the rearrangement and rerendering.
*/
var DotNetHelper;

// initializes a DotNetObjectReference to enable calling C# from Javascript
// called by Index.razor
window.setDotNetObjRef = (dotNetHelper) => {
    DotNetHelper = dotNetHelper;
}

// when drag starts, save the id of the object being dragged
function dragstart_handler(ev) {
    ev.dataTransfer.setData("text/plain", ev.target.id);
    ev.dataTransfer.dropEffect = "copy";
}

// get the source and destination of the move and invoke the CardMoved method in Index.razor
function drop_handler(ev) {
    ev.preventDefault();
    var source = ev.dataTransfer.getData("text/plain");
    var dest = ev.target.id;
    if (source != dest) DotNetHelper.invokeMethodAsync("CardMoved", source, dest);
}

function dragover_handler(ev) {
    ev.preventDefault();
}