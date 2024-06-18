using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using System;
using System.Collections.Generic;

namespace MambuConnector.Builders
{
    /// <summary>
    /// Builder to <see cref="SearchCriteria"/>.
    /// </summary>
    public class SearchCriteriaBuilder
    {
        /// <summary>
        /// Filter criteria to search.
        /// </summary>
        private readonly List<FilterCriteria> _filterCriteria = new List<FilterCriteria>();
        /// <summary>
        /// Sorting criteria.
        /// </summary>
        private SortingCriteria _sortingCriteria;
        /// <summary>
        /// Add filter criteria.
        /// </summary>
        /// <param name="field">Field name.</param>
        /// <param name="operator">Filter operator.</param>
        /// <param name="value">Field value.</param>
        /// <returns><see cref="SearchCriteriaBuilder"/>.</returns>
        public SearchCriteriaBuilder AddFilterCriteria(string field, FilterOperator @operator, string value)
        {
            if (string.IsNullOrEmpty(field))
                throw new ArgumentNullException(nameof(field), "Field to filter is required.");

            _filterCriteria.Add(new FilterCriteria
            {
                Field = field,
                Operator = @operator,
                Value = string.IsNullOrEmpty(value) ? null : value
            });

            return this;
        }
        /// <summary>
        /// Add filter criteria without value, used in operators (EMPTY, NOT_EMPTY, TODAY, THIS_WEEK, ETC...).
        /// </summary>
        /// <param name="field">Field name.</param>
        /// <param name="operator">Filter operator.</param>
        /// <returns><see cref="SearchCriteriaBuilder"/>.</returns>
        public SearchCriteriaBuilder AddFilterCriteria(string field, FilterOperator @operator)
            => AddFilterCriteria(field, @operator, null);
        /// <summary>
        /// Add BETWEEN filter.
        /// </summary>
        /// <param name="field">Field name.</param>
        /// <param name="value">First value.</param>
        /// <param name="secondValue">Second value.</param>
        /// <returns><see cref="SearchCriteriaBuilder"/>.</returns>
        public SearchCriteriaBuilder AddBetweenFilter(string field, string value, string secondValue)
        {
            if (string.IsNullOrEmpty(field))
                throw new ArgumentNullException(nameof(field), "Field to filter is required.");

            _filterCriteria.Add(new FilterCriteria { Field = field, Operator = FilterOperator.BETWEEN, Value = value, SecondValue = secondValue });
            return this;
        }
        /// <summary>
        /// Add IN filter.
        /// </summary>
        /// <param name="field">Field name.</param>
        /// <param name="values">Values to match.</param>
        /// <returns><see cref="SearchCriteriaBuilder"/>.</returns>
        public SearchCriteriaBuilder AddInFilter(string field, IEnumerable<string> values)
        {
            if (string.IsNullOrEmpty(field))
                throw new ArgumentNullException(nameof(field), "Field to filter is required.");

            _filterCriteria.Add(new FilterCriteria { Field = field, Operator = FilterOperator.IN, Values = values });
            return this;
        }
        /// <summary>
        /// Set sorting criteria.
        /// </summary>
        /// <param name="field">Field to sorting.</param>
        /// <param name="order">Sorting order.</param>
        /// <returns><see cref="SearchCriteriaBuilder"/>.</returns>
        public SearchCriteriaBuilder SetSorting(string field, SortingOrder order)
        {
            _sortingCriteria = new SortingCriteria { Field = field, Order = order };
            return this;
        }
        /// <summary>
        /// Build search criteria.
        /// </summary>
        /// <returns><see cref="SearchCriteria"/>.</returns>
        public SearchCriteria Build()
        {
            return new SearchCriteria
            {
                FilterCriteria = _filterCriteria,
                SortingCriteria = _sortingCriteria
            };
        }
    }
}
