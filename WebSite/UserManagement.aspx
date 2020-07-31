<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Details</h4>                                
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>UserID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="UserIDTextBox" runat="server" placeholder="User ID"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary" ID="SearchUserIDLinkButton" runat="server" Text="Go" OnClick="SearchUserIDLinkButton_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox CssClass="form-control" ID="FullNameTextBox" runat="server" placeholder="Full Name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>User Status</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="UserStatusTextBox" runat="server" placeholder="User Status" ReadOnly="true"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-success mr-1" ID="ActiveLinkButton" runat="server" Text="Go" OnClick="ActiveLinkButton_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning mr-1" ID="PendingLinkButton" runat="server" Text="Go" OnClick="PendingLinkButton_Click"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger mr-1" ID="InactiveLinkButton" runat="server" Text="Go" OnClick="InactiveLinkButton_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox CssClass="form-control" ID="DOBTextBox" runat="server" placeholder="DOB" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact Number</label>
                                    <asp:TextBox CssClass="form-control" ID="ContactNumberTextBox" runat="server" placeholder="Contact Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control" ID="EmailTextBox" runat="server" placeholder="Email" ReadOnly="true" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>State</label>
                                    <asp:TextBox CssClass="form-control" ID="StateTextBox" runat="server" placeholder="State" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>City</label>
                                    <asp:TextBox CssClass="form-control" ID="CityTextBox" runat="server" placeholder="City" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pin Code</label>
                                    <asp:TextBox CssClass="form-control" ID="PinCodeTextBox" runat="server" placeholder="PinCode" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full Postal Address</label>
                                <asp:TextBox CssClass="form-control" ID="AddressTextBox" runat="server" placeholder="Address" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeleteUserPermanentlyButton" runat="server" Text="Delete User Permanently" OnClick="DeleteUserPermanentlyButton_Click" />
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
                                    <h4>User List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [user_master_table]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered" ID="UserGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="user_id" HeaderText="User ID" SortExpression="user_id" ReadOnly="True" />
                                        <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_number" HeaderText="Contact Number" SortExpression="contact_number" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
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

