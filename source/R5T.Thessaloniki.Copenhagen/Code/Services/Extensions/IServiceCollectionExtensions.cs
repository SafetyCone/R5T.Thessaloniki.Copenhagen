using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Copenhagen;
using R5T.Dacia;
using R5T.Lombardy;
using R5T.Troy;


namespace R5T.Thessaloniki.Copenhagen
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CDriveTemporaryDirectoryPathProvider"/> implementation of <see cref="ITemporaryDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCDriveTemporaryDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<ICDrivePathProvider> addCDrivePathProvider,
            ServiceAction<ITemporaryDirectoryNameConvention> addTemporaryDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ITemporaryDirectoryPathProvider, CDriveTemporaryDirectoryPathProvider>()
                .RunServiceAction(addCDrivePathProvider)
                .RunServiceAction(addTemporaryDirectoryNameConvention)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CDriveTemporaryDirectoryPathProvider"/> implementation of <see cref="ITemporaryDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ITemporaryDirectoryPathProvider> AddCDriveTemporaryDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<ICDrivePathProvider> addCDrivePathProvider,
            ServiceAction<ITemporaryDirectoryNameConvention> addTemporaryDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ITemporaryDirectoryPathProvider>(() => services.AddCDriveTemporaryDirectoryPathProvider(
                addCDrivePathProvider,
                addTemporaryDirectoryNameConvention,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
