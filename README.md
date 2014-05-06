# Dependency injection in WP8 using Autofac
A short demo project that shows how to have inject viewmodels into your views using the [Autofac IoC container](https://code.google.com/p/autofac/).

## Implementation
Our application will display a list of movies. A movie is defined as follows:

```c#
public class MovieViewModel
{
    public string Title { get; set; }
    public string Director { get; set; }
}
```

The movies will be displayed on the **MoviesPage.xaml** page, which will bind to a `MoviesViewModel` instance. This class contains a collection of `MovieViewModel` instances, which is pre-populated with default data in the constructor:

```c#
public class MoviesViewModel
{
    public MoviesViewModel()
    {
        // Populate our collection of movies with default values
        this.Movies = new Collection<MovieViewModel>
                         {
                             new MovieViewModel { Title = "Se7en", Director = "David Fincher" },
                             new MovieViewModel { Title = "12 Angry Men", Director = "Sidney Lumet" },
                             new MovieViewModel { Title = "Inception", Director = "Christoper Nolan" },
                             new MovieViewModel { Title = "The Matrix", Director = "The Wachowski Brothers" },
                             new MovieViewModel { Title = "Jurassic Park", Director = "Steven Spielberg" },
                             new MovieViewModel { Title = "Back to the Future", Director = "Robert Zemeckis" }
                         };
    }

    public ICollection<MovieViewModel> Movies { get; private set; }
}
```

Note that we use POCO objects for our viewmodels to keep the example as simple as possible. Normally, you would create dependency properties for the movie's title and director and might use an `ObservableCollection` for the movies.
    
Our application has one page, **MoviesPage.xaml** that will bind to an instance of our `MoviesViewModel` class. The point of this demo is to be able to use dependency injection to point to the `MoviesViewModel` instance to bind against. In other words, the code-behind of the movies page, **MoviesPage.xaml.cs**, does not create the `MoviesViewModel` the view uses. For this we will request an instance with a custom viewmodel locator. Lets continue with creating the viewmodel locator.

The viewmodel locator class will need to have properties for all values that we want to resolve dynamically. In our case, we want to be able to dynamically resolve a `MoviesViewModel` instance from our movies page.

The first step in creating the viewmodel locator class is to prepare the inversion of control container (in our case Autofac). We do this by registering the `MoviesViewModel` type with our IoC container:

```c#
public class ViewModelLocator
{
    private readonly IContainer container;

    public ViewModelLocator()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<MoviesViewModel>();

        // Create an IContainer instance which can resolve the registered types
        this.container = containerBuilder.Build();
    }        
}
```

After the constructor has completed, we have an `IContainer` instance which we can ask to dynamically resolve a `MoviesViewModel` instance. To allow easy access from our movies page, we encapsulate this functionality in a property:

```c#
public MoviesViewModel MoviesViewModel
{
    get
    {
        return this.container.Resolve<MoviesViewModel>();
    }
}
```

The `ViewModelLocator` class is now almost ready to be used from our views. The only thing that remains to be done is to have it be available globally in all views. We do this by adding it as a resource in the --**App.xaml** file:

```xml
<Application.Resources>
    <local:ViewModelLocator xmlns:local="clr-namespace:AutofacWP8DependencyInjectionDemo" x:Key="ViewModelLocator"/>
</Application.Resources>
```

Now we are ready to dynamically bind our viewmodel in our movies page. To do so, we define the data context of our **MoviesPage.xaml** page as follows:

```xml
DataContext="{Binding Path=MoviesViewModel, Source={StaticResource ViewModelLocator}}"
```
   
And that is all! If you run the application you will see the default movies be displayed, with the viewmodel dynamically being resolved using our custom `ViewModelLocator` class. As a result, the code-behind of our page is completely empty:

```c#
public partial class MoviesPage : PhoneApplicationPage
{
    public MoviesPage()
    {
        this.InitializeComponent();
    }
}
```

## License
[Apache License 2.0](LICENSE.md)
