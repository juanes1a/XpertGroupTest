using System;
using XpertGroup.CubeSummation.Application.Operator;
using XpertGroup.CubeSummation.Application.Validator;
using XpertGroup.CubeSummation.Domain.Entities;
using XpertGroup.CubeSummation.Domain.Interfaces;
using XpertGroup.CubeSummation.Domain.Interfaces.Orchestrator;

namespace XpertGroup.CubeSummation.Services.Orchestrator
{
    public class Orchestrator : IOrchestrator
    {

        public IOperator Operator { get; set; }

        public Orchestrator(IOperator Operator)
        {
            this.Operator = Operator;
        }

        /// <summary>
        /// Gets the update operation instance.
        /// </summary>
        /// <param name="updateEntrance">The update entrance.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">La sentencia UPDATE no tiene los parametros indicados, deben ser 5 parametros separados por espacio. Ejemplo UPDATE x y z W</exception>
        public Update GetUpdateOperationInstance(string updateEntrance)
        {
            string[] updateSentence = updateEntrance.Split(' ');
            if (updateSentence.Length == 5)
            {
                Update update = new Update(
                    coordinateX: int.Parse(updateSentence[1]),
                    coordinateY: int.Parse(updateSentence[2]),
                    coordinateZ: int.Parse(updateSentence[3]),
                    value: long.Parse(updateSentence[4]));

                return update;
            }

            throw new ApplicationException("La sentencia UPDATE no tiene los parametros indicados, deben ser 5 parametros separados por espacio. Ejemplo UPDATE x y z W");
        }


        /// <summary>
        /// Gets the query operation instance.
        /// </summary>
        /// <param name="queryEntrance">The query entrance.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">La sentencia QUERY no tiene los parametros indicados, deben ser 7 parametros separados por espacio. Ejemplo QUERY x1 x2 y1 y2 z1 z2</exception>
        public Query GetQueryOperationInstance(string queryEntrance)
        {
            string[] updateSentence = queryEntrance.Split(' ');
            if (updateSentence.Length == 7)
            {
                Query query = new Query(
                    new int[] { int.Parse(updateSentence[1]), int.Parse(updateSentence[4]) },
                    new int[] { int.Parse(updateSentence[2]), int.Parse(updateSentence[5]) },
                    new int[] { int.Parse(updateSentence[3]), int.Parse(updateSentence[6]) }
                    );
                return query;
            }

            throw new ApplicationException("La sentencia QUERY no tiene los parametros indicados, deben ser 7 parametros separados por espacio. Ejemplo QUERY x1 x2 y1 y2 z1 z2");
        }

        /// <summary>
        /// Validates the configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public Domain.Entities.ValidationResult ValidateConfiguration(Configuration configuration)
        {
            ConfigurationValidator validator = new ConfigurationValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(configuration);
            return GetValidationResultResponse(results);
        }

        /// <summary>
        /// Validates the update sentence.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public Domain.Entities.ValidationResult ValidateUpdateSentence(Update sentence, Configuration configuration)
        {
            UpdateValidator validator = new UpdateValidator(configuration.MatrixDimension);
            FluentValidation.Results.ValidationResult results = validator.Validate(sentence);
            return GetValidationResultResponse(results);
        }

        /// <summary>
        /// Validates the query sentence.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public Domain.Entities.ValidationResult ValidateQuerySentence(Query sentence, Configuration configuration)
        {
            QueryValidator validator = new QueryValidator(configuration.MatrixDimension);
            FluentValidation.Results.ValidationResult results = validator.Validate(sentence);
            return GetValidationResultResponse(results);
        }

        /// <summary>
        /// Executes the update sentence.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="updateSentence">The update sentence.</param>
        /// <returns></returns>
        public bool ExecuteUpdateSentence(Cube cube, Update updateSentence)
        {
            return Operator.ExecuteUpdate(cube, updateSentence);
        }

        /// <summary>
        /// Executes the query sentence.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <param name="querySentence">The query sentence.</param>
        /// <returns></returns>
        public long ExecuteQuerySentence(Cube cube, Query querySentence)
        {
            return Operator.ExecuteQuery(cube, querySentence);
        }

        /// <summary>
        /// Gets the validation result response.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns></returns>
        private Domain.Entities.ValidationResult GetValidationResultResponse(FluentValidation.Results.ValidationResult results)
        {
            Domain.Entities.ValidationResult response = new Domain.Entities.ValidationResult();
            response.IsValid = results.IsValid;
            if (results.Errors.Count > 0)
            {
                foreach (var error in results.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }

            return response;
        }




    }
}
