<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PublisherManagement.aspx.cs" Inherits="PublisherManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/publisher.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Publisher ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="PublisherIDTextBox" runat="server" placeholder="Publisher ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="SearchPublisherIDButton" runat="server" Text="Go" OnClick="SearchPublisherIDButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Publisher Name</label>
                                    <asp:TextBox CssClass="form-control" ID="PublisherNameTextBox" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="AddPublisherButton" runat="server" Text="Add" OnClick="AddPublisherButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-warning btn-block btn-lg" ID="UpdatePubisherButton" runat="server" Text="Update" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeletePublisherButton" runat="server" Text="Delete" OnClick="DeletePublisherButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                    <h4>Publisher List</h4>
                                </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:sqldatasource runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_table]"></asp:sqldatasource>
                            <asp:GridView CssClass="table table-striped table-bordered" ID="PublisherGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                    <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_table]"></asp:SqlDataSource>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        </div>
        
    </div>
</asp:Content>

