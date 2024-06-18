using MambuConnector.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define transaction channels repository.
    /// </summary>
    public interface ITransactionChannelsRepository
    {
        /// <summary>
        /// Get transaction channel by id.
        /// </summary>
        /// <param name="id">The ID of the transaction channel.</param>
        /// <returns>Transaction channel data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Get all transaction channels.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of transaction channels.</returns>
        Task<MambuResponse> GetAll(Dictionary<string, string> parameters);
        /// <summary>
        /// Get all transaction channels.
        /// </summary>
        /// <returns>Collection of transaction channels.</returns>
        Task<MambuResponse> GetAll();
    }
}
