using XpertGroup.CubeSummation.Domain.Entities;

namespace XpertGroup.CubeSummation.Domain.Interfaces.Orchestrator
{
    public interface IOrchestrator
    {
        /// <summary>
        /// Executes the process.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        ValidationResult ExecuteProcess(Cube cube, Configuration configuration, string input);

        /// <summary>
        /// Validates the configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        ValidationResult ValidateConfiguration(Configuration configuration);
    }
}