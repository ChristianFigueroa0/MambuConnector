namespace MambuConnector.Models.Enums
{
    /// <summary>
    /// Supported filter operators.
    /// </summary>
    public enum FilterOperator
    {
        /// <summary>
        /// Checks for equality, case insensitive.
        /// </summary>
        EQUALS,
        /// <summary>
        /// Checks for equality, case sensitive.
        /// </summary>
        EQUALS_CASE_SENSITIVE,
        /// <summary>
        /// Checks if the value is greater than the specified value.
        /// </summary>
        MORE_THAN,
        /// <summary>
        /// Checks if the value is less than the specified value.
        /// </summary>
        LESS_THAN,
        /// <summary>
        /// Checks if the value is between two specified values.
        /// </summary>
        BETWEEN,
        /// <summary>
        /// Checks if the date value is on the specified date.
        /// </summary>
        ON,
        /// <summary>
        /// Checks if the date value is after the specified date.
        /// </summary>
        AFTER,
        /// <summary>
        /// Checks if the date value is before the specified date.
        /// </summary>
        BEFORE,
        /// <summary>
        /// Checks if the date value is before or on the specified date.
        /// </summary>
        BEFORE_INCLUSIVE,
        /// <summary>
        /// Checks if the value starts with the specified string, case insensitive.
        /// </summary>
        STARTS_WITH,
        /// <summary>
        /// Checks if the value starts with the specified string, case sensitive.
        /// </summary>
        STARTS_WITH_CASE_SENSITIVE,
        /// <summary>
        /// Checks if the value is within a list of specified values.
        /// </summary>
        IN,
        /// <summary>
        /// Checks if the date value is today.
        /// </summary>
        TODAY,
        /// <summary>
        /// Checks if the date value is within this week.
        /// </summary>
        THIS_WEEK,
        /// <summary>
        /// Checks if the date value is within this month.
        /// </summary>
        THIS_MONTH,
        /// <summary>
        /// Checks if the date value is within this year.
        /// </summary>
        THIS_YEAR,
        /// <summary>
        /// Checks if the date value is within the last specified number of days.
        /// </summary>
        LAST_DAYS,
        /// <summary>
        /// Checks if the field is empty.
        /// </summary>
        EMPTY,
        /// <summary>
        /// Checks if the field is not empty.
        /// </summary>
        NOT_EMPTY
    }
}