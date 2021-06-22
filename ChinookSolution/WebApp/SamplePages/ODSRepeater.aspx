<%@ Page Title="Repeater Controller" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSRepeater.aspx.cs" Inherits="WebApp.SamplePages.ODSRepeater" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="offset-1">
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <div class="row">
        <div class="offset-2">
            <asp:Repeater ID="EmployeeCustromers" runat="server" 
                DataSourceID="EmployeeCustomerODS"
                ItemType="ChinookSystem.ViewModels.EmployeeItem">
                <HeaderTemplate>
                    <h3>Sales Support Employees</h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <br />
                    <%#Item.FullName %> (<%#Item.Title %>) has
                    <%#Item.NumberOfCustomers %> customers
                    <br /><br />
                    <%--<asp:GridView ID="CustomersOfEmployee" runat="server"
                        DataSource='<%#Item.CustomerList %>'
                        ItemType="ChinookSystem.ViewModels.CustomerItem">
                    </asp:GridView>--%>
                    <asp:Repeater ID="CustomersOfEmployee" runat="server"
                        DataSource='<%#Item.CustomerList %>'
                        ItemType="ChinookSystem.ViewModels.CustomerItem">
                       <ItemTemplate>
                            Name:<%#Item.FullName %>&nbsp;&nbsp;
                           Phone:<%#Item.Phone %>&nbsp;&nbsp;
                           City:<%#Item.City %>&nbsp;&nbsp;
                           State:<%#Item.State == null ? "Unknown" : Item.State %>&nbsp;&nbsp;<br />
                       </ItemTemplate>
                    </asp:Repeater>

                </ItemTemplate>
                <SeparatorTemplate>
                    <hr style ="height:2px" />
            </SeparatorTemplate>
            </asp:Repeater>
            
        </div>
    </div>
    <asp:ObjectDataSource 
        ID="EmployeeCustomerODS" 
        runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Employee_EmployeeCustomers"
        OnSelected="SelectCheckForException"
        TypeName="ChinookSystem.BLL.EmployeeController"></asp:ObjectDataSource>
</asp:Content>
