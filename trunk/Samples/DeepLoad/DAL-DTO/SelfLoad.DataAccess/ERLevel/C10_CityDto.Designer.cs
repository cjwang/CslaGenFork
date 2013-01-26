using System;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for C10_City type
    /// </summary>
    public partial class C10_CityDto
    {
        /// <summary>
        /// Gets or sets the parent Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Parent_Region_ID { get; set; }

        /// <summary>
        /// Gets or sets the 5_Cities ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int City_ID { get; set; }

        /// <summary>
        /// Gets or sets the 5_Cities Name.
        /// </summary>
        /// <value>The City Name.</value>
        public string City_Name { get; set; }
    }
}
