namespace PedidosAPI.NewFolder
{
    public class TimeProviderService
    {
        public TimeProvider TimeProvider { get; }

        public TimeProviderService()
        {
            TimeProvider = TimeProvider.System;
        }
    }

}
