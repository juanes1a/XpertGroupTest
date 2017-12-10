using XpertGroup.Test.Domain.Entities;

namespace XpertGroup.Test.Domain.Interfaces
{
    public interface IOperator
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="querySentence">The query sentence.</param>
        /// <returns></returns>
        long ExecuteQuery(Cube cube, Query querySentence);

        /// <summary>
        /// Executes the update.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="updateSentence">The update sentence.</param>
        /// <returns></returns>
        bool ExecuteUpdate(Cube cube, Update updateSentence);
    }
}