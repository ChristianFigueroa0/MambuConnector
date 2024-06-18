using MambuConnector.Models;
using MambuConnector.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define deposit product repository.
    /// </summary>
    public interface IDepositProductsRepository
    {
        /// <summary>
        /// Get deposit product.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit product to be returned.</param>
        /// <returns>Deposit product data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Get deposit product.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit product to be returned.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Deposit product data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get all deposit products.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of deposit products.</returns>
        Task<MambuResponse> GetAll(Dictionary<string, string> parameters);
        /// <summary>
        /// Get all deposit products.
        /// </summary>
        /// <returns>Collection of deposit products.</returns>
        Task<MambuResponse> GetAll();
    }
}
