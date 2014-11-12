CouchDesignDocuments
=====================

This library provides a clean and structured way to specify CouchDB design documents within a Visual Studio solution. Grab the Nuget at http://www.nuget.org/packages/CouchDesignDocuments/ .


No JavaScript Strings
---------------------

One part of a design document are the various javascript functions, most notably the map and reduce functions of views. CouchDesignDocuments is able to extract these functions from actual JS files, so that you as a developer can leverage the IDE to edit your design document functions. This works by embedding the JS files in the assembly ("build action" set to "embedded resource"), one file per function.


Views are Symbols
-----------------

In order to query a view, the design document ID and the view name has to be known. Instead of specifying these as strings, CouchDesignDocuments offer another way: Since views are specified as nested classes of the design document class, it becomes possible to retrieve the view name through reflection and expression trees.


Example
---------

For a full example with working code and the recommended directory structure, take a look at the test project inside the VS solution.

Here is a very simple design document, specified using CouchDesignDocuments:

```csharp

using TheDmi.CouchDesignDocuments;

public class ExampleDesignDocument : DesignDocument
{
    // A name of "example" leads to a document ID of "_design/example"
    public override string Name { get { return "example"; } } 

    // Views must reside in a nested class that inherits ViewsSection
    public class Views : ViewsSection<Views>
    {
        // This view will load the map function from an embedded resource
        // "MyView.js" in the folder "Views"
        public static ViewSpec MyView { get { return MapView(); } }
    }
}
```
