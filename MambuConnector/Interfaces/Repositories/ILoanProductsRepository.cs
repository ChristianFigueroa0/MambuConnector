using MambuConnector.Models;
using MambuConnector.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define loan products repository.
    /// </summary>
    public interface ILoanProductsRepository
    {
        /// <summary>
        /// Get loan product by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan product.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan product data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get loan product by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan product.</param>
        /// <returns>Loan product data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Get all loan products.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of loan products.</returns>
        Task<MambuResponse> GetAll(Dictionary<string, string> parameters);
        /// <summary>
        /// Get all loan products.
        /// </summary>
        /// <returns>Collection of loan products.</returns>
        Task<MambuResponse> GetAll();
    }
}
