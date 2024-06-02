<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="LMS.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" class="img-fluid" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Registration</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="dd-mm-yy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label style="margin-top:15px">Contact Number</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label style="margin-top:15px">Email ID</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">
                                <label style="margin-top:15px">State</label>
                                <div class="form-group">
                                    
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        
                                          <asp:ListItem Text="Select" Value="select" />
                                          <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                                          <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                                          <asp:ListItem Text="Assam" Value="Assam" />
                                          <asp:ListItem Text="Bihar" Value="Bihar" />
                                          <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                                          <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                          <asp:ListItem Text="Goa" Value="Goa" />
                                          <asp:ListItem Text="Gujarat" Value="Gujarat" />
                                          <asp:ListItem Text="Haryana" Value="Haryana" />
                                          <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                                          <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                                          <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                                          <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                          <asp:ListItem Text="Kerala" Value="Kerala" />
                                          <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                                          <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                          <asp:ListItem Text="Manipur" Value="Manipur" />
                                          <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                                          <asp:ListItem Text="Mizoram" Value="Mizoram" />
                                          <asp:ListItem Text="Nagaland" Value="Nagaland" />
                                          <asp:ListItem Text="Odisha" Value="Odisha" />
                                          <asp:ListItem Text="Punjab" Value="Punjab" />
                                          <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                          <asp:ListItem Text="Sikkim" Value="Sikkim" />
                                          <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                                          <asp:ListItem Text="Telangana" Value="Telangana" />
                                          <asp:ListItem Text="Tripura" Value="Tripura" />
                                          <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                                          <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                                          <asp:ListItem Text="West Bengal" Value="West Bengal" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label style="margin-top:15px">City</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="City" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label style="margin-top:15px">Pin Code</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <label style="margin-top:15px">Full Address</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <span style="margin-top:15px" class="badge rounded-pill bg-info text-dark">Login Credentials</span>
                                </center>
                            </div>
                        </div>
                        
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label style="margin-top:15px">User ID</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label style="margin-top:15px">Password</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button style="margin-top:15px" class="btn btn-success w-100 btn-lg mr-1" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Homepage</a><br><br />
            </div>
        </div>
    </div>

</asp:Content>
