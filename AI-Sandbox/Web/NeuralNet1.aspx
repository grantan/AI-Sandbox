<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NeuralNet1.aspx.cs" Inherits="AI_Sandbox.Web.NeuralNet1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblInputs" runat="server" Text="Training Set X Y"></asp:Label>
            </div>
            <div style="float:left">
                <asp:GridView ID="gvTrainingInputs" runat="server" ></asp:GridView>
            </div>            
            <div>
                <asp:GridView ID="gvTrainingOutputs" runat="server" BorderWidth="2" ></asp:GridView>
            </div> 
        </div>       

        <br />

        <div style="display:inline-block">
            <div>
                <asp:Label ID="lblWeights" runat="server" Text="Random Weights"></asp:Label>
            </div>
        
            <div style="float:left">
                <asp:GridView ID="gvInitialWeights" runat="server"></asp:GridView>

            </div>
             <div>
                <asp:GridView ID="gvFinalWeights" runat="server" BorderWidth="2"></asp:GridView>

            </div>
        </div>

        <br />
        <br />
        
        <div>
            <div>
                <asp:Label ID="lblL0DotWeights" runat="server" Text="L0 dot Weights"></asp:Label>
            </div>      
        
            <div>
                <asp:GridView ID="gvL0DotWeights" runat="server" > </asp:GridView>
            </div>
        </div>
        <div>
            <asp:Button ID="btnProcess" runat="server" Text="Process!" OnClick="btnProcess_Click" />

        </div>
    </form>
</body>
</html>
