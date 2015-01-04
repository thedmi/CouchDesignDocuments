
# CouchDesignDocuments

This library provides a clean and structured way to specify CouchDB design documents within a Visual Studio solution. Grab the Nuget at http://www.nuget.org/packages/CouchDesignDocuments/ .

This library *is not a CouchDB client*. In fact, it works with any client library (e.g. MyCouch), because design documents are converted to ordinary JSON strings.


## No JavaScript Strings

One part of a design document are the various javascript functions, most notably the map and reduce functions of views. CouchDesignDocuments is able to extract these functions from actual JS files, so that you as a developer can leverage the IDE to edit your design document functions. This works by embedding the JS files in the assembly ("build action" set to "embedded resource"), one file per function.

The biggest benefit of this is that view functions don't have to be encoded as C#-strings.


## Views are Symbols

In order to query a view, the design document ID and the view name has to be known. Instead of specifying these as strings, CouchDesignDocuments offer another way: Since views are specified as nested classes of the design document class, it becomes possible to retrieve the view name through reflection and expression trees.


## Usage

### Defining Design Documents

Create the following directory structure in your VS project:

```
DesignDocuments/ (or any other name you like)
    Views/
        ExampleView1.js
        ExampleView2.js
        ExampleView2.reduce.js
    ExampleDesignDocument.cs

```


Set the "Build Action" of all JS files to "Embedded Resource". The JS files are normal JavaScript source files that contain map or reduce functions:

```javascript
(   
    /* Returns all persons by last name */ 
    function(doc) {
        if (doc.type === 'person') {
            emit(doc.lastName, null);
        }
    }
);

```


And here is how the `ExampleDesignDocument` looks like:

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
        // "ExampleView1.js" in the folder "Views"
        public static ViewSpec ExampleView1 { get { return MapView(); } }

        // This view will load both the JS files "ExampleView2.js" as map 
        // function and "ExampleView2.reduce.js" as reduce function
        public static ViewSpec ExampleView2 { get { return MapReduceView(); } }
    }
}

```

Note that this structure is fixed, so the design document classes should just be used to define the design functions, don't do anything else in here.


### Convert to JSON

At some point you will want to add the design document to your database, so you need it as JSON document:

```csharp

string jsonDoc = DesignDocumentConvert.Serialize(new ExampleDesignDocument);

// Now send the jsonDoc to CouchDB using your favorite CouchDB library

```


### Query a View

The design document contains information about the views, so we can use this to query a specific view:

```csharp

var designDoc = new ExampleDesignDocument();

var viewIdentifier = designDoc.GetViewIdentifier(
        () => ExampleDesignDocument.Views.ExampleView1);

// Now use the viewIdentifier to assemble URIs to query the view
viewIdentifier.DesignDocumentName  // "example"
viewIdentifier.DesignDocumentId    // "_design/example"
viewIdentifier.ViewId              // "my_view1"

```



