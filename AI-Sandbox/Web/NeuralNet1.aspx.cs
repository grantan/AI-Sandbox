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
        public SimpleNeuralNetwork neuralNet { get; set; }
        // L0 =  (inputConnectionsCount, trainingSetSize)
        int[,] TrainingInputsXL0 = new int[4, 3] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 }, { 0, 0, 1 } };

        // Y = (inputConnectionsCount, outputConnectionSize) 
        int[,] TrainingOutputsY = new int[4, 1] { { 0 }, { 1 }, { 1 }, { 0 } };  //4 rows, 1 column

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                BindTrainingInputs();
                BindTrainingOutputs();                
            }
            
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            neuralNet = new SimpleNeuralNetwork(TrainingInputsXL0, TrainingOutputsY);
            BindInitialWeights();
            BindInputDotWeights();
        }        

        private void BindTrainingInputs()
        {
            string columHeaderPrefix = "Input_";
            gvTrainingInputs.DataSource = DataTableUtil.ArrayToDataTableInt(TrainingInputsXL0, columHeaderPrefix);
            gvTrainingInputs.DataBind();
        }

        private void BindTrainingOutputs()
        {
            string columHeaderPrefix = "Output_";
            gvTrainingOutputs.DataSource = DataTableUtil.ArrayToDataTableInt(TrainingOutputsY, columHeaderPrefix);
            gvTrainingOutputs.DataBind();
        }

        private void BindInitialWeights()
        {
            string columHeaderPrefix = "InitialWeight_";
            gvInitialWeights.DataSource = DataTableUtil.ArrayToDataTableFloat(neuralNet.SynapticWeightsInitial, columHeaderPrefix);
            gvInitialWeights.DataBind();
        }

        private void BindInputDotWeights()
        {
            //do we still remember neural net values?  Nope
            string columHeaderPrefix = "XL0DotInitialWeight_";
            gvL0DotWeights.DataSource = DataTableUtil.ArrayToDataTableFloat(neuralNet.XL0DotInitialWeights, columHeaderPrefix);
            gvL0DotWeights.DataBind();

            //if we don't remember nn values, get them from the grids?? oh no
            

            

        }
    }
}