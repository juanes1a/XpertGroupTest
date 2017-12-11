using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertGroup.CubeSummation.Domain.Entities
{
    public class Query
    {
        /// <summary>
        /// Gets or sets the coordinates x.
        /// </summary>
        /// <value>
        /// The coordinates x.
        /// </value>
        public int[] CoordinatesX { get; set; }

        /// <summary>
        /// Gets or sets the coordinates y.
        /// </summary>
        /// <value>
        /// The coordinates y.
        /// </value>
        public int[] CoordinatesY { get; set; }

        /// <summary>
        /// Gets or sets the coordinates z.
        /// </summary>
        /// <value>
        /// The coordinates z.
        /// </value>
        public int[] CoordinatesZ { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        /// <param name="coordinatesX">The coordinates x.</param>
        /// <param name="coordinatesY">The coordinates y.</param>
        /// <param name="coordinatesZ">The coordinates z.</param>
        public Query(int[] coordinatesX, int[] coordinatesY, int[] coordinatesZ)
        {
            this.CoordinatesX = coordinatesX;
            this.CoordinatesY = coordinatesY;
            this.CoordinatesZ = coordinatesZ;
        }


    }
}
