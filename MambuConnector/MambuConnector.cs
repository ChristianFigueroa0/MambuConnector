using MambuConnector.Interfaces;
using MambuConnector.Interfaces.Repositories;
using System;

namespace MambuConnector
{
    /// <summary>
    /// Implementation of <see cref="IMambuConnector"/>.
    /// </summary>
    internal class MambuConnector : IMambuConnector
    {
        /// <summary>
        /// Branches repository.
        /// </summary>
        public IBranchesRepository Branches { get; }
        /// <summary>
        /// Client repository.
        /// </summary>
        public IClientsRepository Clients { get; }
        /// <summary>
        /// Deposit accounts repository.
        /// </summary>
        public IDepositAccountsRepository DepositAccounts { get; }
        /// <summary>
        /// Loan account repository.
        /// </summary>
        public ILoanAccountsRepository LoanAccounts { get; }
        /// <summary>
        /// Loan products repository.
        /// </summary>
        public ILoanProductsRepository LoanProducts { get; }
        /// <summary>
		/// Deposit products repository.
		/// </summary>
		public IDepositProductsRepository DepositProducts { get; }
        /// <summary>
        /// Loan transactions repository.
        /// </summary>
        public ILoanTransactionsRepository LoanTransactions { get; }
        /// <summary>
        /// Deposit transactions repository.
        /// </summary>
        public IDepositTransactionsRepository DepositTransactions { get; }
        /// <summary>
        /// Groups repository.
        public IGroupsRepository Groups { get; }
        /// <summary>
        /// User repository.
        public IUsersRepository Users { get; }
        /// <summary>
        /// Transaction channels repository.
        /// </summary>
        public ITransactionChannelsRepository TransactionChannels { get; }
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="branches">Branches repository.</param>
        /// <param name="clients">Clients repository.</param>
        /// <param name="depositAccounts">Deposit accounts repository.</param>
        /// <param name="loanAccounts">Loan accounts repository.</param>
        /// <param name="loanProducts">Loan products repository.</param>
        /// <param name="depositProducts">Deposit products repository.</param>
        /// <param name="loanTransactions">Loan transactions repository.</param>
        /// <param name="depositTransactions">Deposit transactions repository.</param>
        /// <param name="groups">Groups repository.</param>
        /// <param name="users">Users repository.</param>
        /// <param name="transactionChannels">Transactions channels repository.</param>
        public MambuConnector(
            IBranchesRepository branches,
            IClientsRepository clients,
            IDepositAccountsRepository depositAccounts,
            ILoanAccountsRepository loanAccounts,
            ILoanProductsRepository loanProducts,
            IDepositProductsRepository depositProducts,
            ILoanTransactionsRepository loanTransactions,
            IDepositTransactionsRepository depositTransactions,
            IGroupsRepository groups,
            IUsersRepository users,
            ITransactionChannelsRepository transactionChannels)
        {
            Branches = branches ?? throw new ArgumentNullException(nameof(branches));
            Clients = clients ?? throw new ArgumentNullException(nameof(clients));
            DepositAccounts = depositAccounts ?? throw new ArgumentNullException(nameof(depositAccounts));
            LoanAccounts = loanAccounts ?? throw new ArgumentNullException(nameof(loanAccounts));
            LoanProducts = loanProducts ?? throw new ArgumentNullException(nameof(loanProducts));
            DepositProducts = depositProducts ?? throw new ArgumentNullException(nameof(depositProducts));
            LoanTransactions = loanTransactions ?? throw new ArgumentNullException(nameof(loanTransactions));
            DepositTransactions = depositTransactions ?? throw new ArgumentNullException(nameof(depositTransactions));
            Groups = groups ?? throw new ArgumentNullException(nameof(groups));
            Users = users ?? throw new ArgumentNullException(nameof(users));
            TransactionChannels = transactionChannels ?? throw new ArgumentNullException(nameof(transactionChannels));
        }
    }
}