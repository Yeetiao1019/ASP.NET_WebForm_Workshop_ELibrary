<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookInventory.aspx.cs" Inherits="BookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0])
                var reader = new FileReader();
            reader.onload = function (e) {
                $('#ImgView').attr('src', e.target.result);
            };
            reader.readAsDataURL(input.files[0]);
        }
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
                                    <h4>Book Details</h4>                                
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="ImgView" src="imgs/books.png" width="100"/>
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
                                <asp:FileUpload CssClass="form-control" ID="BookCoverUpload" runat="server" onchange="readURL(this);"/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Book ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="BookIDTextBox" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary" ID="SearchBookIDLinkButton" runat="server" Text="Go" OnClick="SearchBookIDLinkButton_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Book Name</label>
                                    <asp:TextBox CssClass="form-control" ID="BookNameTextBox" runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Language</label>
                                    <asp:DropDownList CssClass="form-control" ID="LanguageDropDownList" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marathi" Value="Marathi" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Urdu" Value="Urdu" />
                                    </asp:DropDownList>
                                    <label>Publisher Name</label>
                                    <asp:DropDownList CssClass="form-control" ID="PublisherNameDropDownList" runat="server">
                                        <asp:ListItem Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:DropDownList CssClass="form-control" ID="AuthorNameDropDownList" runat="server">
                                        <asp:ListItem Text="Tom" Value="Tom"></asp:ListItem>
                                        <asp:ListItem Text="Polo" Value="Polo"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label>Publisher Date</label>
                                    <asp:TextBox CssClass="form-control" ID="PublisherDateTextBox" runat="server" placeholder="Publisher Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Genre</label>
                                    <asp:ListBox CssClass="form-control" ID="GenreListBox" runat="server" SelectionMode="Multiple" Rows="4">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                        <asp:ListItem Text="Self Help" Value="Self Help" />
                                        <asp:ListItem Text="Motivation" Value="Motivation" />
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                        <asp:ListItem Text="Wellness" Value="Wellness" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Suspense" Value="Suspense" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Math" Value="Math" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Edition</label>
                                    <asp:TextBox CssClass="form-control" ID="EditionTextBox" runat="server" placeholder="Edition"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Book Cost(per unit)</label>
                                    <asp:TextBox CssClass="form-control" ID="BookCostTextBox" runat="server" placeholder="Book Cost"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pages</label>
                                    <asp:TextBox CssClass="form-control" ID="PagesTextBox" runat="server" placeholder="Pages"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Actual Stock</label>
                                    <asp:TextBox CssClass="form-control" ID="ActualStockTextBox" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Current Stock</label>
                                    <asp:TextBox CssClass="form-control" ID="CurrentStockTextBox" runat="server" placeholder="Currnet Stock" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Issued Books</label>
                                    <asp:TextBox CssClass="form-control" ID="IssuedBooksTextBox" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Book Description</label>
                                    <asp:TextBox CssClass="form-control" ID="BookDescriptionTextBox" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="AddBookDetailButton" runat="server" Text="Add" OnClick="AddBookDetailButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="UpdateBookDetailButton" runat="server" Text="Update" OnClick="UpdateBookDetailButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeleteBookDetailButton" runat="server" Text="Delete" OnClick="DeleteBookDetailButton_Click" />
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
                                    <h4>Book Inventory List</h4>
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
                                <asp:SqlDataSource ID="BookInventorySqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_table]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered" ID="BookInventoryGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="BookInventorySqlDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="True" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="Publisher Name" SortExpression="publisher_name" />
                                        <asp:BoundField DataField="publish_date" HeaderText="Publish Date" SortExpression="publish_date" />
                                        <asp:BoundField DataField="language" HeaderText="Language" SortExpression="language" />
                                        <asp:BoundField DataField="edition" HeaderText="Edition" SortExpression="edition" />
                                        <asp:BoundField DataField="number_of_pages" HeaderText="Number of Pages" SortExpression="number_of_pages" />
                                        <asp:BoundField DataField="book_description" HeaderText="Book Description" SortExpression="book_description" />
                                        <asp:BoundField DataField="actual_stock" HeaderText="Actual Stock" SortExpression="actual_stock" />
                                        <asp:BoundField DataField="current_stock" HeaderText="Current Stock" SortExpression="current_stock" />
                                        <asp:BoundField DataField="book_img_link" HeaderText="Book Img Link" SortExpression="book_img_link" />
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

