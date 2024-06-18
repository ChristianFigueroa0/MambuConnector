using MambuConnector.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MambuConnector.Extensions
{
    public static class ClientSearchBuilderExtension
    {
        public static SearchCriteriaBuilder FilterByCurp(this SearchCriteriaBuilder searchCriteriaBuilder, string curp)
        {
            searchCriteriaBuilder.AddFilterCriteria("_datoadicional_Curp", Models.Enums.FilterOperator.EQUALS_CASE_SENSITIVE, curp);
            return searchCriteriaBuilder;
        }
    }
}
