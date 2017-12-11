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
                CleanTextBoxes();

                Configuration configuration = Configuration;

                if (configuration.TestCases == 0)
                {
                    configuration.TestCases = int.Parse(txtInputCode.Text.ToString());
                    Configuration = configuration;
                    return;
                }

                if (configuration.MatrixDimension == 0 && configuration.NumberOperations == 0)
                {

                    SetConfiguration();
                    return;
                }

                ExecuteSentences();

            }
            catch (Exception ex)
            {
                txtValidationErrors.Text += ex.Message;
            }
        }

        /// <summary>
        /// Executes the sentences.
        /// </summary>
        private void ExecuteSentences()
        {
            Cube cube = Cube;
            Configuration configuration = Configuration;

            if (cube.ExecutedOrders < Configuration.NumberOperations && Configuration.TestCases > 0)
            {
                string operation = txtInputCode.Text.ToUpper();
                ValidationResult response = Orchestrator.ExecuteProcess(cube, configuration, operation);
                if (response.IsValid)
                {
                    txtOutputCode.Text = response.OutPut.Equals("N/A") ? "" : response.OutPut;
                }
                else
                {
                    WriteErrors(response);
                }

                lblNumberOperationsExecuted.Text = "Numero de operaciones  ejecutadas para este caso de prueba: " + cube.ExecutedOrders.ToString();
                Cube = cube;
            }
            else
            {
                Cube = null;
                SetConfiguration();
            }
        }


        /// <summary>
        /// Sets the configuration.
        /// </summary>
        private void SetConfiguration()
        {
            Configuration configuration = Configuration;
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

            Configuration = configuration;
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

        /// <summary>
        /// Cleans the text boxes.
        /// </summary>
        private void CleanTextBoxes()
        {
            txtOutputCode.Text = string.Empty;
            txtValidationErrors.Text = string.Empty;
            lblCurrentInput.Text = txtInputCode.Text;
        }
    }
}