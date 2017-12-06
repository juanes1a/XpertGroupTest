using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertGroup.Test.Dominio.Entidades
{
    public class Query
    {
        /// <summary>
        /// Gets or sets the xcoordinates.
        /// </summary>
        /// <value>
        /// The xcoordinates.
        /// </value>
        public int[] Xcoordinates { get; set; }

        /// <summary>
        /// Gets or sets the ycoordinates.
        /// </summary>
        /// <value>
        /// The ycoordinates.
        /// </value>
        public int[] Ycoordinates { get; set; }

        /// <summary>
        /// Gets or sets the zcoordinates.
        /// </summary>
        /// <value>
        /// The zcoordinates.
        /// </value>
        public int[] Zcoordinates { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        /// <param name="Xcoordinates">The xcoordinates.</param>
        /// <param name="Ycoordinates">The ycoordinates.</param>
        /// <param name="Zcoordinates">The zcoordinates.</param>
        public Query(int[] Xcoordinates, int[] Ycoordinates, int[] Zcoordinates)
        {
            this.Xcoordinates = Xcoordinates;
            this.Ycoordinates = Ycoordinates;
            this.Zcoordinates = Zcoordinates;
        }


    }
}
