using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflections
{
    public class DependencyInjection
    {
        public static void Run()
        {
            SimpleContainer container = new SimpleContainer();

            container.Register<IMessageService, MessageService>();
            container.Register<INotificationService, NotificationService>();

            INotificationService notification =
                container.Resolve<INotificationService>();

            notification.Send("Hello from Dependency Injection!");
        }
    }

    [AttributeUsage(AttributeTargets.Constructor)]
    public class InjectAttribute : Attribute
    {
    }

    public interface IMessageService
    {
        void SendMessage(string message);
    }

    public class MessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Message Service: {message}");
        }
    }

    public interface INotificationService
    {
        void Send(string message);
    }

    public class NotificationService : INotificationService
    {
        private readonly IMessageService messageService;

        [Inject]
        public NotificationService(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public void Send(string message)
        {
            messageService.SendMessage(message);
        }
    }

    public class SimpleContainer
    {
        private readonly Dictionary<Type, Type> registrations = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>()
        {
            registrations[typeof(TInterface)] = typeof(TImplementation);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (registrations.TryGetValue(type, out Type implementation))
            {
                type = implementation;
            }

            ConstructorInfo constructor = type
                .GetConstructors()
                .FirstOrDefault(c => c.IsDefined(typeof(InjectAttribute), false));

            constructor = constructor ?? type.GetConstructors().FirstOrDefault();

            if (constructor == null)
            {
                throw new Exception($"No constructor found for {type.Name}");
            }

            ParameterInfo[] parameters = constructor.GetParameters();

            object[] dependencies = parameters
                .Select(parameter => Resolve(parameter.ParameterType))
                .ToArray();

            return constructor.Invoke(dependencies);
        }
    }
}
