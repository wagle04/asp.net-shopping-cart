<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_cart.aspx.cs" Inherits="view_cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="b1" runat="server" Text="View Cart" OnClick="b1_Click" />
            <asp:DataList ID="d1" runat="server">
                <HeaderTemplate>
                <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><img src="<%#Eval("product_images") %>" height="100" width="100" /></td>
                        <td><%#Eval ("product_name") %></td>
                        <td><%#Eval ("product_desc") %></td>
                        <td><%#Eval ("product_price") %></td>
                        <td><%#Eval ("product_qty") %></td>
                    </tr>                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
            <asp:Label ID="l1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
