using XpertGroup.Test.Domain.Entities;

namespace XpertGroup.Test.Domain.Interfaces.Orchestrator
{
    public interface IOrchestrator
    {
        /// <summary>
        /// Gets the query operation instance.
        /// </summary>
        /// <param name="queryEntrance">The query entrance.</param>
        /// <returns></returns>
        Query GetQueryOperationInstance(string queryEntrance);

        /// <summary>
        /// Gets the update operation instance.
        /// </summary>
        /// <param name="updateEntrance">The update entrance.</param>
        /// <returns></returns>
        Update GetUpdateOperationInstance(string updateEntrance);

        /// <summary>
        /// Validates the configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        ValidationResult ValidateConfiguration(Configuration configuration);

        /// <summary>
        /// Validates the update sentence.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        ValidationResult ValidateUpdateSentence(Update sentence, Configuration configuration);

        /// <summary>
        /// Validates the query sentence.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        ValidationResult ValidateQuerySentence(Query sentence, Configuration configuration);

        /// <summary>
        /// Executes the update sentence.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="updateSentence">The update sentence.</param>
        /// <returns></returns>
        bool ExecuteUpdateSentence(Cube cube, Update updateSentence);

        /// <summary>
        /// Executes the query sentence.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="querySentence">The query sentence.</param>
        /// <returns></returns>
        long ExecuteQuerySentence(Cube cube, Query querySentence);
    }
}