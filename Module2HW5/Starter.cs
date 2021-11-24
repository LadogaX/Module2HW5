using System;
using System.IO;
using Modul2HW5;
using Module2HW5;
using Module2HW5.Services.Abstractions;

namespace Modul2HW1
{
    public class Starter
    {
        private readonly IActions _action;

        public Starter(ILogger logger)
        {
            Logger = logger;
            _action = new Actions(Logger);
        }

        public ILogger Logger { get; }
        public void Run()
        {
            var rnd = new Random();

            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (rnd.Next(3))
                    {
                        case 0:
                            _action.Method_1();
                            break;
                        case 1:
                            _action.Method_2();
                            break;
                        case 2:
                            _action.Method_3();
                            break;
                    }
                }
                catch (BusinessException businessException)
                {
                    Logger.LogWarning($"Action got this custom Exception," +
                        $" {businessException.Message} in method: {businessException.TargetSite.Name}");
                }
                catch (Exception exception)
                {
                    Logger.LogError($"Action failed by reason," +
                        $" {exception.Message} in method: {exception.TargetSite.Name}");
                }
            }
        }
    }
}
