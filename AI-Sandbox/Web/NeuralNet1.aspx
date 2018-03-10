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
                <asp:Label ID="lblInputs" runat="server" Text="L0 Inputs"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvTraining" runat="server" ></asp:GridView>
            </div>            
        </div>

        <br />

        <div>
            <div>
                <asp:Label ID="lblWeights" runat="server" Text="Random Weights"></asp:Label>
            </div>
        
            <div>
                <asp:GridView ID="gvWeights" runat="server"></asp:GridView>

            </div>
        </div>

        <br />
        
        <div>
            <div>
                <asp:Label ID="lblDot" runat="server" Text="L0 dot Weights Results"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvDotProduct" runat="server" >

                </asp:GridView>
            </div>
        </div>
        <div>
            <asp:Button ID="btnProcess" runat="server" Text="Process!" OnClick="btnProcess_Click" />

        </div>
    </form>
</body>
</html>
