using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XpertGroup.CubeSummation.Domain.Entities;
using XpertGroup.CubeSummation.Domain.Interfaces.Orchestrator;

namespace XpertGroup.CubeSummation.WebSite
{
    public partial class _Default : Page
    {
        public Configuration Configuration
        {
            get
            {
                return (Configuration)ViewState["Configuration"] == null ? new Configuration() : (Configuration)ViewState["Configuration"];
            }
            set
            {
                ViewState["Configuration"] = value;
            }
        }

        public Cube Cube
        {
            get
            {
                return (Cube)ViewState["Cube"] == null ? new Cube(this.Configuration) : (Cube)ViewState["Cube"];
            }
            set
            {
                ViewState["Cube"] = value;
            }
        }

        private readonly IOrchestrator Orchestrator = Global.Container.Resolve<IOrchestrator>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }


        }

        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration configuration = Configuration;

                if (configuration.TestCases == 0)
                {
                    configuration.TestCases = int.Parse(txtInputCode.Text.ToString());
                    Configuration = configuration;
                    return;
                }

                if (configuration.MatrixDimension == 0 && configuration.NumberOperations == 0)
                {
                    configuration.MatrixDimension = int.Parse(txtInputCode.Text.Split(' ')[0]);
                    configuration.NumberOperations = int.Parse(txtInputCode.Text.Split(' ')[1]);

                    ValidationResult response = Orchestrator.ValidateConfiguration(configuration);
                    if (!response.IsValid)
                    {
                        WriteErrors(response);
                    }

                    lblTestCases.Text = "Casos de prueba restantes: " + configuration.TestCases.ToString();
                    lblNumberOperations.Text = "Numero de operaciones para este caso de prueba: " + configuration.NumberOperations.ToString();
                    lblNumberOperationsExecuted.Text = "Numero de operaciones  ejecutadas para este caso de prueba: " + Cube.ExecutedOrders.ToString();

                    this.Configuration = configuration;
                    return;
                }

                ExecuteSentences();

            }
            catch (Exception ex)
            {
                txtValidationErrors.Text += ex.Message;
            }
        }

        private void ExecuteSentences()
        {
            Cube cube = Cube;
            if (cube.ExecutedOrders < Configuration.NumberOperations && Configuration.TestCases > 0)
            {
                string operation = txtInputCode.Text.Split(' ')[0].ToUpper();
                ValidationResult response;

                switch (operation)
                {
                    case "UPDATE":
                        Update update = Orchestrator.GetUpdateOperationInstance(txtInputCode.Text.ToUpper());
                        response = Orchestrator.ValidateUpdateSentence(update, Configuration);
                        if (response.IsValid)
                        {
                            if (Orchestrator.ExecuteUpdateSentence(cube, update))
                            {
                                lblNumberOperationsExecuted.Text = "Numero de operaciones  ejecutadas para este caso de prueba: " + cube.ExecutedOrders.ToString();
                                Cube = cube;
                            }
                        }
                        else
                        {
                            WriteErrors(response);
                        }
                        break;

                    case "QUERY":
                        Query query = Orchestrator.GetQueryOperationInstance(txtInputCode.Text.ToUpper());
                        response = Orchestrator.ValidateQuerySentence(query, Configuration);
                        if (response.IsValid)
                        {
                            txtOutputCode.Text = Orchestrator.ExecuteQuerySentence(cube, query) + "\n";
                            lblNumberOperationsExecuted.Text = "Numero de operaciones  ejecutadas para este caso de prueba: " + cube.ExecutedOrders.ToString();
                            Cube = cube;
                        }
                        else
                        {
                            WriteErrors(response);
                        }
                        break;
                    default:
                        btnSendCode.Enabled = false;
                        txtValidationErrors.Text += "La sentencia ingresada no corresponde a ninguna permitida, utilice UPDATE o QUERY" + "\n";
                        break;
                }
            }
            else
            {
                Cube = null;
                Configuration configuration = Configuration;
                configuration.MatrixDimension = int.Parse(txtInputCode.Text.Split(' ')[0]);
                configuration.NumberOperations = int.Parse(txtInputCode.Text.Split(' ')[1]);

                lblTestCases.Text = "Casos de prueba restantes: " + (configuration.TestCases - 1).ToString();
                lblNumberOperations.Text = "Numero de operaciones para este caso de prueba: " + configuration.NumberOperations.ToString();
                lblNumberOperationsExecuted.Text = "Numero de operaciones  ejecutadas para este caso de prueba: " + Cube.ExecutedOrders.ToString();
            }


        }


        private void SetConfiguration()
        {

        }

        /// <summary>
        /// Writes the errors.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        private void WriteErrors(ValidationResult validationResult)
        {
            btnSendCode.Enabled = false;
            foreach (var error in validationResult.Errors)
            {
                txtValidationErrors.Text = txtValidationErrors.Text + "\n" + error;
            }
        }
    }
}