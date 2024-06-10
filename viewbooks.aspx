<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="LMS.viewbooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/2.0.8/css/dataTables.dataTables.min.css">
    <script type="text/javascript" charset="utf8" src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/2.0.8/js/dataTables.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            //$(".table").DataTable();
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-sm-10 mx-auto">
                <center>
                    <h3>Book Inventory List</h3>
                </center>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="card">
                        <div class="card-body">


                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarydbConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                        <columns>
                                            <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />

                                            <asp:TemplateField>
                                                <itemtemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-lg-10">
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row pt-1">
                                                                    <div class="col-lg-12">
                                                                        Author-<asp:Label ID="Label3" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp;| Genre-<asp:Label ID="Label4" runat="server" Text='<%# Eval("genre") %>' Font-Bold="True" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp;| Language-<asp:Label ID="Label5" runat="server" Text='<%# Eval("language") %>' Font-Bold="True" Font-Size="Smaller"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row pt-1">
                                                                    <div class="col-lg-12">
                                                                        Publisher-<asp:Label ID="Label6" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp; | Publish Date-<asp:Label ID="Label7" runat="server" Text='<%# Eval("publish_date") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp; | Pages-<asp:Label ID="Label8" runat="server" Text='<%# Eval("no_of_pages") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp; | Edition-<asp:Label ID="Label9" runat="server" Text='<%# Eval("edition") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row pt-1">
                                                                    <div class="col-lg-12">
                                                                        Cost-<asp:Label ID="Label10" runat="server" Text='<%# Eval("book_cost") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp; | Actual Stock-<asp:Label ID="Label11" runat="server" Text='<%# Eval("actual_stock") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>
                                                                        &nbsp; | Available-<asp:Label ID="Label12" runat="server" Text='<%# Eval("current_stock") %>' Font-Bold="true" Font-Size="Smaller"></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row pt-1">
                                                                    <div class="col-lg-12">
                                                                        Description-<asp:Label ID="Label13" runat="server" Text='<%# Eval("book_description") %>' Font-Bold="true" Font-Size="Smaller" Font-Italic="True"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </itemtemplate>
                                            </asp:TemplateField>

                                        </columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <center>
                <a href="homepage.aspx"><< Back to Home</a><span class="clearfix"></span>
                <br />
                <center>
        </div>
    </div>
</asp:Content>
