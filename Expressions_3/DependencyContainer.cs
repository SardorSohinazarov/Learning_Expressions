using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_3
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    internal class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _registrations[typeof(TInterface)] = typeof(TImplementation);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (!_registrations.ContainsKey(type))
                throw new InvalidOperationException($"No registration for {type}");

            // Konstruktorni olish
            var implementationType = _registrations[type];
            var constructor = implementationType.GetConstructors().First();

            // Parametrlarni tayyorlash
            var parameters = constructor.GetParameters()
                .Select(p => Resolve(p.ParameterType))  // Parameter'larni rekursiv ravishda yaratish
                .ToArray();

            // Expression yordamida obyekt yaratish
            var newExpression = Expression.New(constructor, parameters.Select(p => Expression.Constant(p)).ToArray());

            var lambda = Expression.Lambda<Func<object>>(newExpression);
            var compiledLambda = lambda.Compile();

            return compiledLambda();
        }
    }
}
