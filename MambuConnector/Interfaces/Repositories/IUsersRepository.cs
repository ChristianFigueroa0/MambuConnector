using MambuConnector.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using MambuConnector.Models;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define users repository
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of users.</returns>
        Task<MambuResponse> GetAll(Dictionary<string, string> parameters);
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of users.</returns>
        Task<MambuResponse> GetAll();
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the user.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>User data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the user.</param>
        /// <returns>User data.</returns>
        Task<MambuResponse> GetById(string id);
    }
}
