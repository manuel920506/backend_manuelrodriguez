using ModelLayer.Enums;

namespace ControllerLayer.DTOs.Queries
{
    public class BaseListQueryDTO
    {
        public BaseListQueryDTO()
        {
            SortDirection = SortDirection.Asc;
        }
        /// <summary>
        ///     Increasing or decreasing
        /// </summary> 
        public SortDirection SortDirection { get; set; }

        /// <summary>
        ///     Column to sort on
        /// </summary> 
        public string? SortExpression { get; set; }

        /// <summary>
        ///    Page number
        /// </summary> 
        public int? PageIndex { get; set; }

        /// <summary>
        ///     Items per page
        /// </summary> 
        public int? PageSize { get; set; }
    }
}
