using Castle.MicroKernel;
using Castle.Windsor;
using System.Collections.Generic;

namespace TestInfraestructure
{
    public class ResolverType
    {
        private static IWindsorContainer _windsor = null;
        public static void Initialize()
        {
            _windsor = new WindsorContainer();
        }
        //public ResolverType()
        //{
        //    _windsor = new WindsorContainer();
        //}
        public static IWindsorContainer MyContainer()
        {
            if (_windsor == null)
            {
                _windsor = new WindsorContainer();
            }
            return _windsor;
        }
        public static T GetLogicFactory<T>() => _windsor.Resolve<T>();
        public static T GetLogicFactory<T>(Dictionary<string, object> arguments)
        {
            var castleArguments = new Arguments();

            foreach (var item in arguments)
                castleArguments.Add(item.Key, item.Value);

            return _windsor.Resolve<T>(castleArguments);
        }

        public void Dispose()
        {
            _windsor.Dispose();
        }
        //public IWindsorContainer Windsor => _windsor;
    }
}
