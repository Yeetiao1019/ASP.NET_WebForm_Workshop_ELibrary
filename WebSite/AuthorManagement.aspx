<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AuthorManagement.aspx.cs" Inherits="AuthorManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/writer.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>                                
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
                                    <label>Author ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="AuthorIDTextBox" runat="server" placeholder="Author ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="SearchAuthorIDButton" runat="server" Text="Go" OnClick="SearchAuthorIDButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:TextBox CssClass="form-control" ID="AuthorNameTextBox" runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="AddAuthorButton" runat="server" Text="Add" OnClick="AddAuthorButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-warning btn-block btn-lg" ID="UpdateAuthorButton" runat="server" Text="Update" OnClick="UpdateAuthorButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeleteAuthorButton" runat="server" Text="Delete" OnClick="DeleteAuthorButton_Click" />
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
                                    <h4>Author List</h4>
                                </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_table]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView CssClass="table table-striped table-bordered" ID="AuthorGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                    <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        </div>       
    </div>
</asp:Content>

