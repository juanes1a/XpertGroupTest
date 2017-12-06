using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertGroup.Test.Dominio.Entidades
{
    public class Update
    {

        /// <summary>
        /// Gets or sets the coordinate x.
        /// </summary>
        /// <value>
        /// The coordinate x.
        /// </value>
        public int CoordinateX { get; set; }

        /// <summary>
        /// Gets or sets the coordinate y.
        /// </summary>
        /// <value>
        /// The coordinate y.
        /// </value>
        public int CoordinateY { get; set; }

        /// <summary>
        /// Gets or sets the coordinate z.
        /// </summary>
        /// <value>
        /// The coordinate z.
        /// </value>
        public int CoordinateZ { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Update"/> class.
        /// </summary>
        /// <param name="coordinateX">The coordinate x.</param>
        /// <param name="coordinateY">The coordinate y.</param>
        /// <param name="coordinateZ">The coordinate z.</param>
        public Update(int coordinateX, int coordinateY, int coordinateZ)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.CoordinateZ = coordinateZ;
        }
    }
}
