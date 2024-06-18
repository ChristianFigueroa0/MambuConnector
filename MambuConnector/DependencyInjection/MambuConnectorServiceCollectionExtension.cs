using MambuConnector.Interfaces;
using MambuConnector.Interfaces.Repositories;
using MambuConnector.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace MambuConnector.DependencyInjection
{
    /// <summary>
    /// Extension of <see cref="IServiceCollection"/> to add mambu connector services.
    /// </summary>
    public static class MambuConnectorServiceCollectionExtension
    {
        /// <summary>
        /// Name of http client.
        /// </summary>
        private const string HttpClientName = "MAMBU";
        /// <summary>
        /// Add connector mambu services.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="options">Options to configure mambu instance.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddMambuConnector(this IServiceCollection services, Action<MambuConnectorOptions> options)
        {
            var mambuConnectorOptions = new MambuConnectorOptions();
            options?.Invoke(mambuConnectorOptions);

            if(string.IsNullOrEmpty(mambuConnectorOptions.Url))
                throw new ArgumentNullException(nameof(mambuConnectorOptions.Url));

            if (string.IsNullOrEmpty(mambuConnectorOptions.User))
                throw new ArgumentNullException(nameof(mambuConnectorOptions.User));

            if (string.IsNullOrEmpty(mambuConnectorOptions.Password))
                throw new ArgumentNullException(nameof(mambuConnectorOptions.Password));

            services.AddHttpClient(HttpClientName, client =>
            {
                client.BaseAddress = mambuConnectorOptions.Url.EndsWith('/') ? new Uri(mambuConnectorOptions.Url) : new Uri(mambuConnectorOptions.Url + "/");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.mambu.v2+json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                   Convert.ToBase64String(Encoding.ASCII.GetBytes($"{mambuConnectorOptions.User}:{mambuConnectorOptions.Password}")));
            });

            services.AddRepositories();
            services.AddTransient<IMambuConnector, MambuConnector>();

            return services;
        }
        /// <summary>
        /// Add repositories to services collection.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBranchesRepository, BranchesRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IDepositAccountsRepository, DepositAccountsRepository>();
            services.AddScoped<ILoanAccountsRepository, LoanAccountsRepository>();
            services.AddScoped<ILoanProductsRepository, LoanProductsRepository>();
            services.AddScoped<IDepositProductsRepository, DepositProductsRepository>();
            services.AddScoped<ILoanTransactionsRepository, LoanTransactionsRepository>();
            services.AddScoped<IDepositTransactionsRepository, DepositTransactionsRepository>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITransactionChannelsRepository, TransactionChannelsRepository>();

            return services;
        }
    }
}
