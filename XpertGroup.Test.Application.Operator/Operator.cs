using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpertGroup.Test.Domain.Entities;
using XpertGroup.Test.Domain.Interfaces;

namespace XpertGroup.Test.Application.Operator
{
    public class Operator : IOperator
    {

        public Operator() { }

        /// <summary>
        /// Executes the update.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="updateSentence">The update sentence.</param>
        /// <returns></returns>
        public bool ExecuteUpdate(Cube cube, Update updateSentence)
        {
            try
            {
                cube.Matrix[updateSentence.CoordinateX - 1, updateSentence.CoordinateY - 1, updateSentence.CoordinateZ - 1] = updateSentence.Value;

                cube.ExecutedOrders++;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="querySentence">The query sentence.</param>
        /// <returns></returns>
        public long ExecuteQuery(Cube cube, Query querySentence)
        {
            try
            {
                long sum = 0;
                for (int i = querySentence.CoordinatesX[0] - 1; i <= querySentence.CoordinatesX[1] - 1; i++)
                {
                    sum += cube.Matrix[i, i, i];
                }

                cube.ExecutedOrders++;

                return sum;
            }
            catch (Exception e)
            {
                return -1;
            }
        }





    }
}
