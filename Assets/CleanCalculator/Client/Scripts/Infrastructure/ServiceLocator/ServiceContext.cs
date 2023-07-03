public class ServiceContext
{
    private static ServiceContext _instance;
    public static ServiceContext Container => _instance ??= new();

    public void RegistrationSingle<TService>(TService implementation) where TService : IService =>
        Implementation<TService>.ServiceInstance = implementation;

    public TService Single<TService>() where TService : IService =>
        Implementation<TService>.ServiceInstance;

    private static class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}