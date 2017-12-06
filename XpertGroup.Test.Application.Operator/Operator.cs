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
                cube.Matrix[updateSentence.CoordinateX, updateSentence.CoordinateY, updateSentence.CoordinateZ] = updateSentence.Value;
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
        public int ExecuteQuery(Cube cube, Query querySentence)
        {
            try
            {
                int firstValue = cube.Matrix[querySentence.Xcoordinates.FirstOrDefault(), querySentence.Ycoordinates.FirstOrDefault(), querySentence.Ycoordinates.FirstOrDefault()];
                int secondValue = cube.Matrix[querySentence.Xcoordinates.LastOrDefault(), querySentence.Ycoordinates.LastOrDefault(), querySentence.Ycoordinates.LastOrDefault()];

                return firstValue + secondValue;
            }
            catch (Exception e)
            {
                return -1;
            }
        }



    }
}
