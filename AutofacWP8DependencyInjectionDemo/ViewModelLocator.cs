namespace AutofacWP8DependencyInjectionDemo
{
    using Autofac;

    /// <summary>
    /// This class will be used to do the dependency injection with. It will have properties for
    /// all components that need to be resolved dynamically.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// The Autofac container instance which we will use for resolving the registered components.
        /// </summary>
        private readonly IContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelLocator"/> class.
        /// </summary>
        public ViewModelLocator()
        {
            // Create the container builder which is used to create the IContainer instance
            var containerBuilder = new ContainerBuilder();

            // Register the two view model types
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<ItemViewModel>();

            // Build the container
            this.container = containerBuilder.Build();
        }

        /// <summary>
        /// Gets the main view model. It does this by dynamically resolving it
        /// from the Autofac container.
        /// </summary>
        public MainViewModel MainViewModel
        {
            get
            {
                return this.container.Resolve<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the item view model. It does this by dynamically resolving it
        /// from the Autofac container.
        /// </summary>
        public ItemViewModel ItemViewModel
        {
            get
            {
                return this.container.Resolve<ItemViewModel>();
            }
        }
    }
}