using DataAccess.Cryptoghraphy;
using DataAccess.Cryptoghraphy.Hashing;
using DataAccess.Cryptoghraphy.Symmetric;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Filters;

namespace WebApi.ServiceCollectionsExtensions
{
    public static class ServicesLifeSpanConfiguration
    {
        public static void AddServicesLifeSpan(this IServiceCollection service)
        {
            service.AddScoped<ValidationFilterAttribute>();
            service.AddScoped<NullReferencesCheckAttribute>();
            service.AddSingleton<ISecretStore, SecretStore>();
            service.AddScoped<IHasher, Hasher>();
            service.AddScoped<ISymmetricEncryptor, SymmetricEncryptor>();
            service.AddScoped<ICryptoStoreSimulator, CryptoStoreSimulator>();
        }
    }
}
