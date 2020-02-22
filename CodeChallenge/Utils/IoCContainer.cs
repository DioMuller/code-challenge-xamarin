using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Utils
{
    /// <summary>
    /// Inversion of Control Container. 
    /// </summary>
    public class IoCContainer
    {
        #region Singleton
        static readonly IoCContainer _instance = new IoCContainer();
        public static IoCContainer Instance => _instance;
        #endregion

        #region Attributes
        private IContainer _container;
        private ContainerBuilder _builder;
        #endregion

        #region Constructor
        private IoCContainer() => _builder = new ContainerBuilder();
        #endregion

        #region Methods
        public T Resolve<T>() => _container.Resolve<T>();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => _builder.RegisterType<TImplementation>().As<TInterface>();
        public void Register<T>() => _builder.RegisterType<T>();

        public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface => _builder.RegisterType<TImplementation>().As<TInterface>().SingleInstance();
        public void RegisterSingleton<T>() => _builder.RegisterType<T>().SingleInstance();

        public void Build()
        {
            if (_container == null)
                _container = _builder.Build();
        }
        #endregion
    }
}
