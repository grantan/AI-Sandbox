using AI_Sandbox.AI;
using AI_Sandbox.DataUtil;
using AI_Sandbox.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AI_Sandbox.Web
{
    public partial class NeuralNet1 : System.Web.UI.Page
    {
        public SimpleNeuralNetwork neuralNet;

        protected void Page_Load(object sender, EventArgs e)
        {
            neuralNet = new SimpleNeuralNetwork();

            if (!IsPostBack)
            {
                BindTrainingInputs();
                BindInitialWeights();
            }
            
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            BindInputDotWeights();
        }        

        private void BindTrainingInputs()
        {
            
            gvTraining.DataSource = DataTableUtil.ArrayToDataTableInt(neuralNet.TrainingInputsXL0);
            gvTraining.DataBind();
        }

        private void BindInitialWeights()
        {
            gvWeights.DataSource = DataTableUtil.ArrayToDataTableFloat(neuralNet.SynapticWeightsSyn0);
            gvWeights.DataBind();
        }

        private void BindInputDotWeights()
        {
            //do we still remember neural net values?  Nope

            float[,] dotProd = MatrixOperations.DotProduct(neuralNet.TrainingInputsXL0, neuralNet.SynapticWeightsSyn0);
            gvDotProduct.DataSource = DataTableUtil.ArrayToDataTableFloat(dotProd);
            gvDotProduct.DataBind();

            //if we don't remember nn values, get them from the grids?? oh no
            

            

        }
    }
}