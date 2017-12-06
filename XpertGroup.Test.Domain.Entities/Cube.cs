using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertGroup.Test.Domain.Entities
{
    public class Cube
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the matrix.
        /// </summary>
        /// <value>
        /// The matrix.
        /// </value>
        public int[,,] Matrix { get; set; }

        /// <summary>
        /// Gets or sets the executed orders.
        /// </summary>
        /// <value>
        /// The executed orders.
        /// </value>
        public int ExecutedOrders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cube"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Cube(Configuration configuration)
        {
            this.Configuration = configuration;
            this.Matrix = new int[this.Configuration.MatrixDimension, this.Configuration.MatrixDimension, this.Configuration.MatrixDimension];
            this.ExecutedOrders = 0;
        }
    }
}
