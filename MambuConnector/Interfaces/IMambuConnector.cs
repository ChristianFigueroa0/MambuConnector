using MambuConnector.Interfaces.Repositories;

namespace MambuConnector.Interfaces
{
    /// <summary>
    /// Define mambu connector service.
    /// </summary>
    public interface IMambuConnector
    {
        /// <summary>
        /// Branches repository.
        /// </summary>
        IBranchesRepository Branches { get; }
        /// <summary>
        /// Client repository.
        /// </summary>
        IClientsRepository Clients { get; }
        /// <summary>
        /// Deposit accounts repository.
        /// </summary>
        IDepositAccountsRepository DepositAccounts { get; }
        /// <summary>
        /// Loan account repository.
        /// </summary>
        ILoanAccountsRepository LoanAccounts { get; }
        /// <summary>
        /// Loan products repository.
        /// </summary>
        ILoanProductsRepository LoanProducts { get; }
        /// <summary>
		/// Deposit products repository.
		/// </summary>
		IDepositProductsRepository DepositProducts { get; }
        /// <summary>
        /// Loan transactions repository.
        /// </summary>
        ILoanTransactionsRepository LoanTransactions { get; }
        /// <summary>
        /// Deposit transactions repository.
        /// </summary>
        IDepositTransactionsRepository DepositTransactions { get; }
        /// <summary>
        /// Groups repository.
        IGroupsRepository Groups { get; }
        /// <summary>
        /// User repository.
        IUsersRepository Users { get; }
        /// <summary>
        /// Transaction channels repository.
        /// </summary>
        ITransactionChannelsRepository TransactionChannels { get; }
    }
}