<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewBooks.aspx.cs" Inherits="ViewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col mx-auto">
                <div class="row">
                    <div class="col">
                        <center>
                           <h4>Book Inventory List</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView CssClass="table table-striped table-bordered" ID="BookInventoryListGridView" runat="server"></asp:GridView>
                    </div>
                </div>

            </div>
        </div>
        <a href="HomePage.aspx"><< Back to Home</a><span class="clearfix"></span>
        <br />
    </div>
</asp:Content>

