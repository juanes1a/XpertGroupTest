using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertGroup.Test.Domain.Entities
{
    public class Configuration
    {
        /// <summary>
        /// Gets or sets the test cases.
        /// </summary>
        /// <value>
        /// The test cases.
        /// </value>
        public int TestCases { get; set; }

        /// <summary>
        /// Gets or sets the matrix dimension.
        /// </summary>
        /// <value>
        /// The matrix dimension.
        /// </value>
        public int MatrixDimension { get; set; }

        /// <summary>
        /// Gets or sets the number operations.
        /// </summary>
        /// <value>
        /// The number operations.
        /// </value>
        public int NumberOperations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration(int testCases, int matrizDimension, int numberOperations)
        {
            this.TestCases = testCases;
            this.MatrixDimension = matrizDimension;
            this.NumberOperations = NumberOperations;
        }
    }
}
